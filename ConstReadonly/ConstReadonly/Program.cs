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
        static void swap(ref int n1, ref int n2)
        {
            int temp;
            temp= n1;
            n1 = n2;
            n2 = temp;
        }

        static void calculate(float radius, out float area, out float circum)
        {
            area = 3.14f * radius * radius;
            circum = 2 * 3.14f* radius; 
        }

        static void Main(string[] args)
        {
            MathEngine mathEngine = new MathEngine();
            mathEngine.display();

            //using enum
            WeekDays day = WeekDays.Mon;
            Console.WriteLine("day: {0}",day);

            Months mon = Months.April;
            Console.WriteLine("Month: {0}", mon);


            //Array
            int[] type1;
            int[] type2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] type3 = new int[] { 1, 2 };

            //string
            string[] str = new string[] { "sanika", "Sumit" };

            //list
            List<string> list = new List<string>();
            list.Add("sanika");
            list.Add("sumit");

            //display list
            foreach (string name in list)
            {
                Console.WriteLine(name);
            }

           //params keyword
           void displayData(params string[] data)
            {
                foreach(string d in data)
                {
                    Console.WriteLine(d);
                }
           }
            #region params example
                displayData("sanika", "sumit", "rishika");
                displayData("ravi sir","shubhangi mam");
                displayData("papa","mummy","brother","me");
            #endregion

            //call by refernce
            //ref keyword
            int mumbaiPopulation = 4932246;
            int punePopulation = 8496;

            Console.WriteLine("before swapping population");
            Console.WriteLine("mumbai population: {0}",mumbaiPopulation);
            Console.WriteLine("pune population: {0}",punePopulation);

            swap(ref punePopulation, ref mumbaiPopulation);

            Console.WriteLine("after swapping population");
            Console.WriteLine("mumbai population: {0}", mumbaiPopulation);
            Console.WriteLine("pune population: {0}", punePopulation);

            //out keyword
            float area;
            float circum;
            float radius = 4;

            calculate(radius, out area, out circum);
            Console.WriteLine("area: {0}",area);
            Console.WriteLine("circumfernce: {0}", circum);
        }
    }
}
