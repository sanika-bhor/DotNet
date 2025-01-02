//OCP(Open Closed Principle)
namespace OCP
{
    public interface IAccount
    {
        public double Balance{get; set;}
        public void CalculateInterest();
    }

    public class RegularSavingAccount:IAccount
    {
        public double Balance{get; set;}=0;
        public void CalculateInterest()
        {
            Console.WriteLine("Enter Balance: ");
            Balance=double.Parse(Console.ReadLine());

            //logic to calculate interest
            double interest=0;
            if(Balance >5000)
            {
               interest=(Balance*2)/100;
            }
            else if(Balance<=5000 )
            {
                interest=(Balance*4)/100;
            }
            Console.WriteLine("Interest for Regular Saving Account: "+interest);
            
        }
    }

    public class SalarySavingAccount:IAccount
    {
        public double Balance{get; set;}=0;
        public void CalculateInterest()
        {
             Console.WriteLine("Enter Balance: ");
            Balance=double.Parse(Console.ReadLine());
            
             double interest=(Balance*5)/100;
             Console.WriteLine("Interest for Salary Saving Account: "+interest);
        }
    }

    public class CorporateSavingAccount:IAccount
    {
        public double Balance{get; set;}=0;
        public void CalculateInterest()
        {
             Console.WriteLine("Enter Balance: ");
            Balance=double.Parse(Console.ReadLine());
            
             double interest=(Balance*3)/100;
             Console.WriteLine("Interest for Corporate Saving Account: "+interest);
        }
    }
}