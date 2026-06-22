using TFLBank.Listener;
using TFLBank.NotificationServices;
using TFLBank.TransactionManager.operations;
using TFLBank.models;
using TFLBank.FileManager;

namespace ActionListener.publishers
{
    public class AccountsDepartment : IDepositOperation, IWithdrawOperation, IFundTransferOperation
    , ICreateAccountOperation,IMiniStatement
    {

        public List<Account> accounts { get; set; }
        public List<Operation> allOperations=new List<Operation>();
        private List<IAccountsHandler> listeners = new List<IAccountsHandler>();
        private INotificationService notificationService;
        private IAccountsRepository accountsRepository;
        private IOperationsRepository operationsRepository;

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
    }
}