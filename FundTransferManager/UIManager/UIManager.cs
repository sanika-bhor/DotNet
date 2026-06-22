using FundTransfer.models;

namespace FundTransfer.UIManager
{
    public class UIManager
    {
        public void displayMenu()
        {
             Console.WriteLine("***********************************************************");
             Console.WriteLine("****************************MENU***************************");
             Console.WriteLine("***********************************************************");
             Console.WriteLine("1.check balance ");
             Console.WriteLine("2.withdraw");
             Console.WriteLine("3.Deposite");
             Console.WriteLine("4.Transfer fund");
             Console.WriteLine("5.create new account");
             Console.WriteLine("6.Exit");
             Console.WriteLine("***********************************************************");
        }
        public int getChoice()
        {
             Console.WriteLine("enter your choice: ");
             int choice=int.Parse(Console.ReadLine());
             return choice;
        }

        public void exitApplication()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("           THANK YOU FOR USING OUR APPLICATION             ");
            Console.WriteLine("***********************************************************");
        }

        public void displayBalance(double balance)
        {
            Console.WriteLine("Current Balance: "+balance);
        }

        public string enterAccountNumber(string msg="")
        {
            Console.WriteLine(msg+"enter your account number: ");
            string accno = Console.ReadLine();
            return accno;
        }

        public double enterAmount()
        {
            Console.WriteLine("enter Amount: ");
            double amount = double.Parse(Console.ReadLine());
            return amount;
        }

        public void displayMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }


        public  Account getAccountInfo()
        {
            Account account=new Account();
            Console.WriteLine("Enter your name");
            account.Name=Console.ReadLine();

            Console.WriteLine("Enter your email");
            account.Email = Console.ReadLine();

            Console.WriteLine("Enter your AccountNo");
            account.AccountNumber = Console.ReadLine();

            Console.WriteLine("Enter your initial balance");
            account.Balance = double.Parse(Console.ReadLine());

            return account;
        }
    }
}