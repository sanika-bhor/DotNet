using HR_Domin;
namespace HR_Domin.HR
{
    public class SalesEmployee : Employee
    {
        public int Target{ get; set; }

        public double Incentive{ get; set; }

        public SalesEmployee():base()
        {
            Target = 0;
            Incentive=0;
            Console.WriteLine("Constructor from SalesEmployee");
        }

        public SalesEmployee(int id, string name, int age, double baseSalary,int target, double incentive):base(id, name, age,baseSalary)
        {
           Target=target;
           Incentive= incentive;
        }

        public override string ToString()
        {
            return base.ToString()+"\nTarget: "+Target+"\nIncentive: "+Incentive;
        
        }
        public override void DoWork()
        {
            Console.WriteLine("Sales Employee doing his work");
        }

        public override void ComputePay()
        {
            double salary=BaseSalary;
            if (Target>=1000)
            {
                 salary=BaseSalary+Incentive;
            }
            Console.WriteLine("SalesEmployee salary: "+salary);
        }
    }
}