using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstReadonly
{
    //enumuration
    enum WeekDays {Mon, Tue, Wed, Thurs, Fri, Sat};
    enum Months { Jan ,Feb,Mar, April, May, Jun,July, Aug,Sep, Oct,Nov,Dec}

    public class MathEngine
    {
        public readonly double PI; //at the time of declaration it can or cannot be initialized
        public const int count= 32; //at the time of declaration it must have to initialized

        public MathEngine()
        {
            PI = 3.14; // initialized only once
            // count = 35: not allow
        }

        public void display()
        {
            // count = 35: not allow
            // pi = 35: not allow

            Console.WriteLine("count: {0}",count);
            Console.WriteLine("PI: {0}",PI);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MathEngine mathEngine = new MathEngine();
            mathEngine.display();

            //using enum
            WeekDays day = WeekDays.Mon;
            Console.WriteLine("day: {0}",day);

            Months mon = Months.April;
            Console.WriteLine("Month: {0}", mon);

           
        }
    }
}
