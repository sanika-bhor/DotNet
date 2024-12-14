using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    public class SalesEmployee:Employee
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
