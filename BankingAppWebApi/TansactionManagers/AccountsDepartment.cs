using TFLBank.Listener;
using TFLBank.NotificationServices;
using TFLBank.TransactionManager.operations;
using TFLBank.models;
using TFLBank.FileManager;

namespace ActionListener.publishers
{
 
    //Interface Saggrigation  Principle
    
    public class AccountsDepartment : IDepositOperation, IWithdrawOperation, IFundTransferOperation, ICalculateInterestOperation, IApplyInterestOperation
    , ICreateAccountOperation,IMiniStatement
    {

        private List<IAccountsHandler> listeners = new List<IAccountsHandler>();
        private readonly INotificationService notificationService;
        private readonly IAccountsRepository accountsRepository;
        private readonly IOperationsRepository operationsRepository;
        private int InterestRate=7;

        public AccountsDepartment( INotificationService notificationService, IAccountsRepository accountsRepository, IOperationsRepository operationsRepository)
        {
            this.notificationService = notificationService;
            this.accountsRepository = accountsRepository;
            this.operationsRepository = operationsRepository;
        }

        public double GetBalance(string accountId)
        {
            //LINQ: Language Intergrated Query
            List<Account> accounts = accountsRepository.GetAllAccounts();
            return accounts.FirstOrDefault(account => account.AccountNumber == accountId)?.Balance ?? 0;
        }

        public bool Deposit(string accountId, double amount)
        {
            bool status = false;
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account != null)
            {
                account.Balance += amount;
                CheckBalance(account);
                status = true;
                accountsRepository.SaveAllAccounts(accounts);
            }
            return status;
        }

        public bool Withdraw(string accountId, double amount)
        {
            bool status = false;
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account != null)
            {
                if (amount > account.Balance)
                {
                    status = false;
                }
                else
                {
                    account.Balance -= amount;
                    CheckBalance(account);
                    status = true;
                    accountsRepository.SaveAllAccounts(accounts);
                }
            }
            return status;

        }
        
        public bool FundTransfer(string fromAccountId, string toAccountId, double amount)
        {
            bool status = false;
            
            List<Account> accounts = accountsRepository.GetAllAccounts();
          
            Account fromAccount = accounts.FirstOrDefault(a => a.AccountNumber == fromAccountId);
            Account toAccount = accounts.FirstOrDefault(a => a.AccountNumber == toAccountId);
            
            bool depositeStatus;

            bool withdrawStatus=Withdraw(fromAccount.AccountNumber,amount);

           if (withdrawStatus)
            {
                depositeStatus=Deposit(toAccount.AccountNumber, amount);
                if(!depositeStatus)
                {
                    Deposit(fromAccount.AccountNumber, amount);
                }
                if (withdrawStatus && depositeStatus)
                {
                    status = true;
                }
            }
           
            return status;
        }
    
         public bool CreateAccount(Account account)
        {
            bool status=false;
            List<Account> accounts = accountsRepository.GetAllAccounts();
            accounts.Add(account);
            accountsRepository.SaveAllAccounts(accounts);
            status =true;
            return status;
        }
      
         public Account GetAccount(string accountId)
        {
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account != null)
            {
                return account;
            }

            return null;
        }

        private void CheckBalance(Account account)
        {

            if (account.Balance < 1000)
            {
                foreach (IAccountsHandler l in listeners)
                {
                    l.OnUnderBalance(account);
                    notificationService.send("Amount is less than  minimum balance policy");
                }
            }

            if (account.Balance > 25000)
            {
                foreach (IAccountsHandler l in listeners)
                {
                    l.OnOverBalance(account);
                    notificationService.send("Amount is greater than  Taxable income policy");
                }
            }



        }

        public void addListener(IAccountsHandler listener)
        {
            listeners.Add(listener);
        }

        public List<Operation> GetMiniStatement(string accountId)
        {
            List<Operation> miniStatement = new List<Operation>();
            List<Operation> allOperations = operationsRepository.GetAllOperations();

            List<Operation> accountOperations = new List<Operation>();
            accountOperations = allOperations
                .Where(o => o.AccountNumber == accountId)
                .ToList();


            for (int i= accountOperations.Count-5;i< accountOperations.Count;i++)
            {
                miniStatement.Add(accountOperations[i]);
            }
            return miniStatement;
        }

        private double Calculate(List<Operation> accountOperations)
        {
            Operation firstOperation = new Operation();
            Operation secondOperation = new Operation();
            double totalInterestNow = 0;

            firstOperation = accountOperations[0];

            double finalInterset = 0;
            for (int i = 1; i < accountOperations.Count(); i++)
            {
                secondOperation = accountOperations[i];
                TimeSpan consecutiveOperationsTimeSpan = secondOperation.OperationON - firstOperation.OperationON;

                double totalDays = consecutiveOperationsTimeSpan.TotalDays;
                // Console.WriteLine("" + totalDays);

                double baseAmount = 1 + (InterestRate / 100.0 / 365.0); //formula for calcuating  daily balance
                // Console.WriteLine(baseAmount);

                double afterpower = Math.Pow(baseAmount, totalDays);
                // Console.WriteLine(afterpower);

                totalInterestNow = firstOperation.CurrentBalance * afterpower;
                // Console.WriteLine("" + totalInterestTillNow);

                double interset = totalInterestNow - firstOperation.CurrentBalance;
                finalInterset += interset;
                firstOperation = secondOperation;

            }
            return finalInterset;
        }

        public double CalculateInterest(string accountId)
        {
            List<Operation> allOperations = new List<Operation>();
            
           

            allOperations = operationsRepository.GetAllOperations();
          
            List<Operation> accountOperations=new List<Operation>();
            accountOperations = allOperations
                .Where(o => o.AccountNumber == accountId)
                .ToList();

            bool userExist = accountOperations.Count > 0;

            if (userExist)
            {
                double finalInterset=Calculate(accountOperations);
                return finalInterset;
            
            }
            else
            {
                return 0;
            }
        }

        public bool ApplyInterest()
        {
            List<Operation> allOperations = new List<Operation>();
            bool applyInterestStatus=false;
            allOperations= operationsRepository.GetAllOperations();
            List<Account> accounts = accountsRepository.GetAllAccounts();
            foreach (Account account in accounts)
            {
               double totalInterest= CalculateInterest(account.AccountNumber);
            
                bool status= Deposit(account.AccountNumber, totalInterest);

               double balance=GetBalance(account.AccountNumber);
                if (status)
                {
                    Operation newOperation = new Operation { AccountNumber = account.AccountNumber, Status = "I", StatusMessage = "Interest is deposited", OperationON = DateTime.Now, Amount = totalInterest, CurrentBalance = balance };
                    allOperations.Add(newOperation);
                    operationsRepository.SaveOpeations(allOperations);
                    applyInterestStatus=true;
                }
                else
                {
                    applyInterestStatus = false;
                }
            }
            return applyInterestStatus;
        }
    }
}