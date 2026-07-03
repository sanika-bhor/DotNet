using ActionListener.publishers.operation;
using ActionListener.Listener;
using ActionListener.Services;

namespace ActionListener.publishers{
public class Account :DepositeOperation, WithdrawOperation{

    private double Balance{get;set;}
    private List<AccountListener> listeners=new List<AccountListener>();
    private NotificationService notificationService;

        public double getBalance()
        {
            return Balance;
        }

        public Account(double amount,NotificationService notificationService)
        {
            this.Balance=amount;
            this.notificationService=notificationService;
        }

        public void  deposite(double amount)
        {
            Balance+=amount;
            checkBalance();
        }


        public void withdraw(double amount)
        {
            Balance-=amount;
            checkBalance();

        }

        private void checkBalance()
        {
            if(Balance<1000)
            {
                foreach(AccountListener l in listeners)
                {
                    l.onUnderBalance(Balance);
                    notificationService.send("Amount is less than  minimum balance policy");
                }
            }

            if (Balance >25000)
            {
                foreach (AccountListener l in listeners)
                {
                    l.onOverBalance(Balance);
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