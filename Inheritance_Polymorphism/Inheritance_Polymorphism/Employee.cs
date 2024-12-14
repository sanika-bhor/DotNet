using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    public class Employee : Person
    {
        public float BasicSalary { get; set; }
        public string Department { get; set; }
        public int WorkingDays {  get; set; }

        public Employee() : base()
        {
            BasicSalary = 200;
            Department = "sales";
        }

        public Employee(int id, string firstName, string lastname, DateTime dob,float basicSalary, string department,int workedDay):base(id,firstName,lastname,dob)
        {
           this.BasicSalary = basicSalary;
           this.Department = department;
            this.WorkingDays = workedDay;
        }

        public virtual float calculate()
        {
            float salary = BasicSalary + (500 * WorkingDays);
            return salary;
        }

        public override string ToString()
        {
            return base.ToString()+" "+Department+" "+BasicSalary+" "+WorkingDays;
        }

    }
}
