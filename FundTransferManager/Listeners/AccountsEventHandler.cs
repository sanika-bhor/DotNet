namespace FundTransfer.Listener
{
    public class AccountEventHandler : AccountListener
    {
        public void onUnderBalance(double balance)
        {
            Console.WriteLine("Amount is less than  minimum balance policy");
        }

        public void onOverBalance(double balance)
        {
            Console.WriteLine("Amount is greater than  Taxable income policy");
        }
    }
}