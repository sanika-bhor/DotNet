using TFLBank.Listener;
using TFLBank.NotificationServices;
using TFLBank.TransactionManager.operations;
using TFLBank.models;
using TFLBank.FileManager;

namespace ActionListener.publishers
{
    public class AccountsDepartment : IDepositOperation, IWithdrawOperation, IFundTransferOperation, ICalculateInterestOperation, IApplyInterestOperation
    , ICreateAccountOperation,IMiniStatement
    {

        public List<Account> accounts { get; set; }
        
        private List<IAccountsHandler> listeners = new List<IAccountsHandler>();
        private INotificationService notificationService;
        private IAccountsRepository accountsRepository;
        private IOperationsRepository operationsRepository;
        private int InterestRate=7;

        public AccountsDepartment(List<Account> account, INotificationService notificationService, IAccountsRepository accountsRepository, IOperationsRepository operationsRepository)
        {
            this.accounts = account;
            this.notificationService = notificationService;
            this.accountsRepository = accountsRepository;
            this.operationsRepository = operationsRepository;
        }


        public double GetBalance(string accountId)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    return account.Balance;
                }
            }
            return 0;
        }


        public bool Deposit(string accountId, double amount)
        {
            bool status = false;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance += amount;
                    CheckBalance(account);
                    status = true;
                    accountsRepository.SaveAllAccounts(accounts);
                    break;
                }
            }
            return status;
        }
        public bool Withdraw(string accountId, double amount)
        {
            bool status=false;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance -= amount;
                    CheckBalance(account);
                    if (account.Balance < 0)
                    {
                        status=false;
                    }
                    else
                    {
                        status=true;
                        accountsRepository.SaveAllAccounts(accounts);
                    }
                    break;
                }
            }

            return status;
        }
        
        public bool FundTransfer(string fromAccountId, string toAccountId, double amount)
        {
            bool status = false;
            Account fromAccount=new Account();
            Account toAccount=new Account();
            foreach(Account account in accounts)
            {
                if (account.AccountNumber == fromAccountId)
                {
                    fromAccount=account;
                    break;
                }
            }

            foreach (Account account in accounts)
            {
                if (account.AccountNumber == toAccountId)
                {
                    toAccount = account;
                    break;
                }
            }
            
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
            accounts.Add(account);
            accountsRepository.SaveAllAccounts(accounts);
            status =true;
            return status;
        }
      
         public Account GetAccount(string accountId)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    return account;
                }
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
            List<Operation> allOperations = new List<Operation>();
            List<Operation> miniStatement = new List<Operation>();
           allOperations= operationsRepository.GetAllOperations();
           int count=0;
           
           foreach(Operation operation in allOperations)

            {
                if (operation.AccountNumber== accountId)
                {
                    miniStatement.Add(operation);
                    count++;
                    if(count==5)
                    {
                        break;
                    }
                }
            }
           return miniStatement;
        }

        public double CalculateInterest(string accountId)
        {
            List<Operation> allOperations = new List<Operation>();
            bool userExist = false;
            Operation firstOperation = new Operation();
            Operation secondOperation=new Operation();
            double totalInterestNow=0;

            allOperations = operationsRepository.GetAllOperations();
          
            List<Operation> accountOperations=new List<Operation>();

            foreach (Operation operation in allOperations)
            {
                if (operation.AccountNumber == accountId)
                {
                    accountOperations.Add(operation);
                    userExist=true;
                }
            }

        if(userExist)
        {

            firstOperation = accountOperations[0];
         
            double finalInterset=0;
            for (int i=1;i< accountOperations.Count();i++)
            {
                secondOperation = accountOperations[i];
                TimeSpan consecutiveOperationsTimeSpan = secondOperation.OperationON - firstOperation.OperationON;

                double totalDays = consecutiveOperationsTimeSpan.TotalDays;
                // Console.WriteLine("" + totalDays);

                double baseAmount= 1 + (InterestRate/100.0 / 365.0); //formula for calcuating  daily balance
                // Console.WriteLine(baseAmount);

                double afterpower = Math.Pow(baseAmount, totalDays);
                // Console.WriteLine(afterpower);

                totalInterestNow = firstOperation.CurrentBalance * afterpower;
                // Console.WriteLine("" + totalInterestTillNow);

                double interset=totalInterestNow- firstOperation.CurrentBalance;
                finalInterset+= interset;
                firstOperation =secondOperation;
            }
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
            foreach (Account account in accounts)
            {
               double totalInterest= CalculateInterest(account.AccountNumber);
               Console.WriteLine(""+totalInterest);
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