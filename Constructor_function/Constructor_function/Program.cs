using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_function
{
    internal class Program
    {

        Program() 
        {
            Console.WriteLine("this is simple constructor");
        }

        Program(int count)
        {
            Console.WriteLine("this is parameterized constructor with count value: {0}",count);
        }

        static int addition(int a, int b)
        {
            return a + b; 
        }

        static int subtraction(int a, int b)
        {
            return a - b;
        }

        void display()
        {
            Console.WriteLine("welcome to the world of programming");
        }

        void displayResult(int result)
        {
            Console.WriteLine("result: {0}",result);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Program paraProgram = new Program(12);

            Console.WriteLine();

            program.display();
            Console.WriteLine();

            int add = addition(25, 30);
            int sub = subtraction(45, 30);

            program.displayResult(add);
            program.displayResult(sub);

        }
    }
}
