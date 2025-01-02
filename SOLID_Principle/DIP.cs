//DIP(dependancy inversion principle)
namespace DIP
{
    public interface IAccount
    {
        public void Login();
        public void Register();
    }

    public class Admin:IAccount
    {
        public void Login()
        {
            Console.WriteLine("validation of Admin");
        }
        public void Register()
        {
            Console.WriteLine("creation of new Admin");
        }
    }

    public class User:IAccount
    {
        public void Login()
        {
            Console.WriteLine("check credential for Customer");
        }
        public void Register()
        {
            Console.WriteLine("creation of new Customer");
        }
    }
    
    public class Employee:IAccount
    {
        public void Login()
        {
            Console.WriteLine("login as employee");
        }
        public void Register()
        {
            Console.WriteLine("add new Employee");
        }
    }

    public class AccountController
    {
        IAccount account;

        public AccountController(IAccount acc)
        {
            this.account =  acc;
        }

        public void Login()
        {
            Console.WriteLine("Before Login Operation");
            account.Login();
            Console.WriteLine(" Login Operation done");
        }

        public void Register()
        {
            Console.WriteLine("Before Register Operation");
            account.Register();
            Console.WriteLine(" Register Operation done");
        }
    }

}