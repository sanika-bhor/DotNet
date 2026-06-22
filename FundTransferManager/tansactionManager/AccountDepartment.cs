using FundTransfer.Listener;
using FundTransfer.NotificationServices;
using FundTransfer.TransactionManager.operations;
using FundTransfer.models;
using FundTransfer.FileManager;

namespace ActionListener.publishers
{
    public class AccountDepartment : DepositeOperation, WithdrawOperation, FundTransferOperation, CreateAccountOperation
    {

        public List<Account> accounts { get; set; }
        private List<AccountListener> listeners = new List<AccountListener>();
        private NotificationService notificationService;
        private IFileManager fileManager;

        public AccountDepartment(List<Account> account, NotificationService notificationService,IFileManager fileManager)
        {
            this.accounts = account;
            this.notificationService = notificationService;
            this.fileManager = fileManager;
        }


        public double getBalance(string accountId)
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


        public bool deposite(string accountId, double amount)
        {
            bool status = false;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance += amount;
                    checkBalance(account);
                    if (amount > 50000)
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                        fileManager.SaveAllAccounts(accounts);
                    }
                    break;
                }
            }
            return status;
        }
        public bool withdraw(string accountId, double amount)
        {
            bool status=false;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance -= amount;
                    checkBalance(account);
                    if (account.Balance < 0)
                    {
                        status=false;
                    }
                    else
                    {
                        status=true;
                        fileManager.SaveAllAccounts(accounts);
                    }
                    break;
                }
            }

            return status;
        }
        
        public bool tranferFund(string fromAccountId, string toAccountId, double amount)
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
            bool withdrawStatus=withdraw(fromAccount.AccountNumber,amount);

           if (withdrawStatus)
            {
                depositeStatus=deposite(toAccount.AccountNumber, amount);
                if(!depositeStatus)
                {
                    deposite(fromAccount.AccountNumber, amount);
                }
                if (withdrawStatus && depositeStatus)
                {
                    status = true;
                }
            }
           
            return status;
        }
    
         public bool createAccount(Account account)
        {
            bool status=false;
            accounts.Add(account);
            fileManager.SaveAllAccounts(accounts);
            status =true;
            return status;
        }
        private void checkBalance(Account account)
        {

            if (account.Balance < 1000)
            {
                foreach (AccountListener l in listeners)
                {
                    l.onUnderBalance(account.Balance);
                    notificationService.send("Amount is less than  minimum balance policy");
                }
            }

            if (account.Balance > 25000)
            {
                foreach (AccountListener l in listeners)
                {
                    l.onOverBalance(account.Balance);
                    notificationService.send("Amount is greater than  Taxable income policy");
                }
            }



        }

        public void addListener(AccountListener listener)
        {
            listeners.Add(listener);
        }
    }
}