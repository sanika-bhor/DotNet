namespace HR_Domin.HR
{
    public class SalesManager : SalesEmployee
    {
        public double Bonus{get;set;}
        public SalesManager():base()
        {
        }

        public SalesManager(int id, string name, int age,double baseSalary,int target, double incentive,double bonus):base(id,name,age,baseSalary,target,incentive)
        {
            Bonus=bonus;
        }

        public override void DoWork()
        {
            Console.WriteLine("Sales Manager doing his work");
        }

        public override string ToString()
        {
            return base.ToString()+"\nBonus: "+Bonus;
        }

        public override void ComputePay()
        {
           double salary=BaseSalary;

           if(Target>1000)
            {
                salary=Bonus+BaseSalary+Incentive;
            }
            Console.WriteLine("SalesManager Salary: "+salary);

        }
    }
}