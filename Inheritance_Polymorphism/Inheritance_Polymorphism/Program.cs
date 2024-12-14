using System;
using HR;

namespace Inheritance_Polymorphism
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime dob=new DateTime(2005,4,27);
            Person person = new Person(1,"sanika","bhor",dob);
            Console.WriteLine(person);

            Employee employee = new Employee(1, "sanika", "bhor", dob, 252000, "HR", 20);
            Console.WriteLine(employee);
            float sal = employee.calculate();
            Console.WriteLine("your salary: {0}",sal);

            SalesEmployee semployee = new SalesEmployee(1, "sanika", "bhor", dob, 252000, "HR", 20,15000);
            Console.WriteLine(semployee);
            float sal_in = semployee.calculate();
            Console.WriteLine("your salary with incentives: {0}", sal_in);




        }
    }
}
