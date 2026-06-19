using FundTransfer.Listener;
using FundTransfer.NotificationServices;
using FundTransfer.TransactionManager.operations;
using FundTransfer.models;

namespace ActionListener.publishers
{
    public class AccountDepartment : DepositeOperation, WithdrawOperation, FundTransferOperation
    {

        public List<Account> accounts { get; set; }
        private List<AccountListener> listeners = new List<AccountListener>();
        private NotificationService notificationService;

        public AccountDepartment(List<Account> account, NotificationService notificationService)
        {
            this.accounts = account;
            this.notificationService = notificationService;
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


        public void deposite(string accountId, double amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance += amount;
                    checkBalance(account);
                    break;
                }
            }


        }
        public void withdraw(string accountId, double amount)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountId)
                {
                    account.Balance -= amount;
                    checkBalance(account);
                    break;
                }
            }

        }
        
        public void tranferFund(Account fromAccount, Account toAccount, double amount)
        {
            withdraw(fromAccount.AccountNumber,amount);
            deposite(toAccount.AccountNumber,amount);
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