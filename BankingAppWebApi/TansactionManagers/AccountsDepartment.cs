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
        private readonly ITransactionsRepository transactionsRepository;
        private int InterestRate=7;

        public AccountsDepartment( INotificationService notificationService, IAccountsRepository accountsRepository, ITransactionsRepository transactionsRepository)
        {
            this.notificationService = notificationService;
            this.accountsRepository = accountsRepository;
            this.transactionsRepository = transactionsRepository;
        }

        public double GetBalance(string accountNumber)
        {
            //LINQ: Language Intergrated Query
            List<Account> accounts = accountsRepository.GetAllAccounts();
            return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber)?.Balance ?? 0;
        }

        public bool Deposit(string accountNumber, double depositAmount)
        {
            bool isDepositSuccessful = false;
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Balance += depositAmount;
                CheckBalance(account);
                isDepositSuccessful = true;
                accountsRepository.SaveAllAccounts(accounts);
            }
            return isDepositSuccessful;
        }

        public bool Withdraw(string accountNumber, double withdrawAmount)
        {
            bool isWithdrawSuccessful = false;
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                if (withdrawAmount > account.Balance)
                {
                    isWithdrawSuccessful = false;
                }
                else
                {
                    account.Balance -= withdrawAmount;
                    CheckBalance(account);
                    isWithdrawSuccessful = true;
                    accountsRepository.SaveAllAccounts(accounts);
                }
            }
            return isWithdrawSuccessful;

        }
        
        public bool FundTransfer(string fromAccountNumber, string toAccountNumber, double transferAmount)
        {
            bool isFundTransferSuccessful = false;
            
            List<Account> accounts = accountsRepository.GetAllAccounts();
          
            Account fromAccount = accounts.FirstOrDefault(a => a.AccountNumber == fromAccountNumber);
            Account toAccount = accounts.FirstOrDefault(a => a.AccountNumber == toAccountNumber);
            
            bool depositeStatus;

            bool withdrawStatus=Withdraw(fromAccount.AccountNumber, transferAmount);

           if (withdrawStatus)
            {
                depositeStatus=Deposit(toAccount.AccountNumber, transferAmount);
                if(!depositeStatus)
                {
                    Deposit(fromAccount.AccountNumber, transferAmount);
                }
                if (withdrawStatus && depositeStatus)
                {
                    isFundTransferSuccessful = true;
                }
            }
           
            return isFundTransferSuccessful;
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
      
         public Account GetAccount(string accountNumber)
        {
            List<Account> accounts = accountsRepository.GetAllAccounts();
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
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

        public List<Transaction> GetMiniStatement(string accountNumber)
        {
            List<Transaction> miniStatement = new List<Transaction>();
            List<Transaction> transactionsHistory = transactionsRepository.LoadTransactions();

            List<Transaction> accountTransactions = new List<Transaction>();
            accountTransactions = transactionsHistory
                .Where(o => o.AccountNumber == accountNumber)
                .ToList();


            for (int i= accountTransactions.Count-5;i< accountTransactions.Count;i++)
            {
                miniStatement.Add(accountTransactions[i]);
            }
            return miniStatement;
        }

        private double Calculate(List<Transaction> accountOperations)
        {
            Transaction firstTransaction = new Transaction();
            Transaction secondTransaction = new Transaction();
            double totalInterestNow = 0;

            firstTransaction = accountOperations[0];

            double finalInterset = 0;
            for (int i = 1; i < accountOperations.Count(); i++)
            {
                secondTransaction = accountOperations[i];
                TimeSpan consecutiveOperationsTimeSpan = secondTransaction.TransactionDate - firstTransaction.TransactionDate;

                double totalDays = consecutiveOperationsTimeSpan.TotalDays;
                // Console.WriteLine("" + totalDays);

                double baseAmount = 1 + (InterestRate / 100.0 / 365.0); //formula for calcuating  daily balance
                // Console.WriteLine(baseAmount);

                double afterpower = Math.Pow(baseAmount, totalDays);
                // Console.WriteLine(afterpower);

                totalInterestNow = firstTransaction.CurrentBalance * afterpower;
                // Console.WriteLine("" + totalInterestTillNow);

                double interset = totalInterestNow - firstTransaction.CurrentBalance;
                finalInterset += interset;
                firstTransaction = secondTransaction;

            }
            return finalInterset;
        }

        public double CalculateInterest(string accountNumber)
        {
            List<Transaction> transactionsHistory = new List<Transaction>();



            transactionsHistory = transactionsRepository.LoadTransactions();
          
            List<Transaction> accountTransactions=new List<Transaction>();
            accountTransactions = transactionsHistory
                .Where(o => o.AccountNumber == accountNumber)
                .ToList();

            bool userExist = accountTransactions.Count > 0;

            if (userExist)
            {
                double finalInterset=Calculate(accountTransactions);
                return finalInterset;
            
            }
            else
            {
                return 0;
            }
        }

        public bool ApplyInterest()
        {
            List<Transaction> transactionsHistory = new List<Transaction>();
            bool applyInterestStatus=false;
            transactionsHistory = transactionsRepository.LoadTransactions();
            List<Account> accounts = accountsRepository.GetAllAccounts();
            foreach (Account account in accounts)
            {
               double totalInterest= CalculateInterest(account.AccountNumber);
            
                bool status= Deposit(account.AccountNumber, totalInterest);

               double balance=GetBalance(account.AccountNumber);
                if (status)
                {
                    Transaction interestTransaction = new Transaction { AccountNumber = account.AccountNumber, TransactionStatus = "I", StatusMessage = "Interest is deposited", TransactionDate = DateTime.Now, Amount = totalInterest, CurrentBalance = balance };
                    transactionsHistory.Add(interestTransaction);
                    transactionsRepository.SaveTransactions(transactionsHistory);
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