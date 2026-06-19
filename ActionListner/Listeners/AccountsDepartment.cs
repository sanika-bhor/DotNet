namespace ActionListener.Listener
{
    public class AccountsDepartment : IActionListener
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