using System;

namespace HR
{

    // to block the inheritance we used keyword: sealed
    //it means we can not create derived class from this sealed class

    public sealed class SalesEmployee:Employee
    {
        public float Incentives {  get; set; }
        public SalesEmployee():base() 
        {
            Incentives = 0;
        }
        public SalesEmployee(int id, string firstName, string lastname, DateTime dob, float basicSalary, string department, int workedDay, float incentives): base(id, firstName, lastname, dob, basicSalary,department,workedDay)
        {
             this.Incentives = incentives;
        }


        public override float calculate()
        {
            return base.calculate()+Incentives;
        }

        public override string ToString()
        {
            return base.ToString()+" "+Incentives;
        }
    }
}
