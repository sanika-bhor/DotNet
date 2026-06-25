using TFLBank.models;

namespace TFLBank.UIManagers
{
    public class UIManager
    {
        public void DisplayMenu()
        {
             Console.WriteLine("****************************MENU***************************");
             Console.WriteLine("1.check balance ");
             Console.WriteLine("2.withdraw");
             Console.WriteLine("3.Deposite");
             Console.WriteLine("4.Transfer fund");
             Console.WriteLine("5.Create New Account");
             Console.WriteLine("6.Get Mini Statement");  
             Console.WriteLine("7.Calculate And Collect Interest");  
             Console.WriteLine("8.All Interest to All");  
             Console.WriteLine("9.Exit");
             Console.WriteLine("***********************************************************");
        }
        public int GetChoice()
        {
             Console.WriteLine("enter your choice: ");
             int choice=int.Parse(Console.ReadLine());
             return choice;
        }

        public void ExitApplication()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("           THANK YOU FOR USING OUR APPLICATION             ");
            Console.WriteLine("***********************************************************");
        }

        public void DisplayBalance(double balance)
        {
            Console.WriteLine("\n***********************************************************");
            Console.WriteLine("Current Balance: "+balance);
            Console.WriteLine("***********************************************************\n");

        }

        public string EnterAccountNumber(string msg="")
        {
            Console.WriteLine(msg+"enter your account number: ");
            string accno = Console.ReadLine();
            return accno;
        }

        public double EnterAmount()
        {
            Console.WriteLine("enter Amount: ");
            double amount = double.Parse(Console.ReadLine());
            return amount;
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }


        public  Account GetAccountInfo()
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

            account.CreatedOn=DateTime.Now;

            return account;
        }

        public void DisplayAccountSummary(Account account)
        {
            Console.WriteLine("Account Number: "+account.AccountNumber);
            Console.WriteLine("Name: "+account.Name);
            Console.WriteLine("Email: "+account.Email);
            Console.WriteLine("Created On: "+account.CreatedOn);
        }

        public void DisplayOperation(Operation operation)
        {
            Console.WriteLine("|     "+operation.Status+"     |    "+operation.StatusMessage+"      |      "+operation.Amount+"     |     "+operation.OperationON +"     |        "+operation.CurrentBalance);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

        }

        public void DisplayHeading()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Operation Type. |           Status              |     Amount     |  Date         |     CurrentBalance      ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

        }
    }
}



//SOC:  