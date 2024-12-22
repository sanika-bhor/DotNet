using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine
{
    public class Complex
    {
        public int real;
        public int img;

        public Complex(int r, int i)
        {
            real = r;
            img = i;
        }
         
        public static Complex operator+(Complex c1, Complex c2)
        {
            Complex temp = new Complex(0, 0);
            temp.real = c2.real + c1.real ;
            temp.img = c2.img + c1.img;
            return temp;
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex temp = new Complex(0, 0);
            temp.real = c2.real - c1.real;
            temp.img = c2.img - c1.img;
            return temp;
        }

    }
}
