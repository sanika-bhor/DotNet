namespace HR_Domin.HR
{
    public class HRManager:Employee
    {
        public double ExtraAllowance;

        public HRManager():base()
        {
            this.ExtraAllowance = 0;
        }

        public HRManager(int id, string name, int age, double baseSalary,double extraAllowance):base(id, name, age,baseSalary)
        {
            ExtraAllowance=extraAllowance;
        }

        public override void DoWork()
        {
           Console.WriteLine("HR is doing his workd");
        }

        public override void ComputePay()
        {
            double salary=BaseSalary+ExtraAllowance;
            Console.WriteLine("HR Salary: "+salary);
        }

        public override string ToString()
        {
            return base.ToString()+"\nExta Allowance: "+ExtraAllowance;
        }
        
        public override bool Equals(object obj)
        {
            if(obj is HRManager)
            {
                return true;
            }
            return false;
        }
    }
}