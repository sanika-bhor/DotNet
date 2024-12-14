using System;
using HR;

namespace Inheritance_Polymorphism
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            DateTime dob=new DateTime(2005,4,27);
            
            //uni test for person class
            Person person = new Person(1,"sanika","bhor",dob);
            Console.WriteLine(person);

            //unit test for emloyee class
            Employee employee = new Employee(1, "sanika", "bhor", dob, 252000, "HR", 20);
            Console.WriteLine(employee);
            float sal = employee.calculate();
            Console.WriteLine("your salary: {0}",sal);

            //unit test for salesemloyee class
            SalesEmployee semployee = new SalesEmployee(1, "sanika", "bhor", dob, 252000, "HR", 20,15000);
            Console.WriteLine(semployee);
            float sal_in = semployee.calculate();
            Console.WriteLine("your salary with incentives: {0}", sal_in);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(); 




            Person prn1 = person;
            Console.WriteLine(prn1);

            Person prn2 = employee;
            Console.WriteLine(prn2);

            Employee prn3 = semployee;
            Console.WriteLine(prn3);




        }
    }
}
