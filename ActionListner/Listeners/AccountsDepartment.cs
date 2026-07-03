namespace ActionListener.Listener
{
    public class AccountsDepartment : AccountListener
    {
        public void onUnderBalance(double balance)
        {
            Console.WriteLine("Department! Current Balance: " + balance);
        }

        public void onOverBalance(double balance)
        {
            Console.WriteLine("Department! Current Balance: " + balance);
        }
    }
}