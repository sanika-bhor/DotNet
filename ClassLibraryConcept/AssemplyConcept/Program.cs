using MathEngine;
using System;

namespace AssemplyConcept
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num1 = 78;
            int num2 = 28;

            int addResult=MathEngines.Addition(num1, num2);
            Console.WriteLine("Addition: {0}", addResult);

            int subResult = MathEngines.Subraction(num1, num2);
            Console.WriteLine("Subtraction: {0}", subResult);

            Complex c1 = new Complex(25, 56);
            Complex c2 = new Complex(23, 34);
            Complex c3 = new Complex(0, 0);

            c3 = c1 + c2;
            Console.WriteLine("Addtion of complex: {0} + {1}j", c3.real,c3.img);
        }
    }
}
