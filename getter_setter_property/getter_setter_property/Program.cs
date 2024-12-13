using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace getter_setter_property
{
    internal class Program
    {

        string Uname;   //field

      
        //simple getter setter
         string getter()
        {
            return Uname;
        }

        void setter(string name)
        {
            Uname = name;
        }


        //get set property
        public string data   //property
        {
            get { return Uname; }
            set { Uname = value; } // here value is a predefined keyword
        }
        static void Main(string[] args)
        {
            string name,surname;
            Program program = new Program();

            //using simple getter setter
            Console.WriteLine("enter name: ");
            name= Console.ReadLine();
            program.setter(name);
            Console.WriteLine("name: {0}",program.getter());


            //using set get property
            Console.WriteLine("enter surname: ");
            surname = Console.ReadLine();
            program.data = surname;
            Console.WriteLine("your surname: {0}", program.data);
            

       
    }
    }
}
