using HR_Domin.HR.Interfaces;

namespace HR_Domin.HR
{
    public class SalesManager : SalesEmployee,IManagerBenefits,IInterviewPanel,ITrainer,IAppraisable
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

        public double CalculateBonus()
        {
            return Bonus;
        }

        public void ConductAppraisal()
        {
            Console.WriteLine("Manager Appraisal Completed.");
        }

        public void ApproveLeave()
        {
           Console.WriteLine("Leave Approved By Sales Manager.");
        }

        public void TakeInterview()
        {
            Console.WriteLine("Sales Manager Conducting interview.");
        }

        public void Train()
        {
            Console.WriteLine("Sales Manager Trainign Sales team");
        }
    }
}