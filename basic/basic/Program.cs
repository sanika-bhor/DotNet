using System;


namespace basic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("welcome tho the world of .NET");

            //count variable with intial value 10
            int count = 10;
            Console.WriteLine(count);

            //read and display data
            string name;
            Console.WriteLine("enter name");
            name = Console.ReadLine();
            Console.WriteLine("your Name {0}: ", name); //way 1 to display data
            Console.WriteLine("your name :" + name);  //another way

            //increment count till 50 ad display result
            if(count <=10)
            {
                while(count <= 50)
                {
                    Console.WriteLine("count {0}", count);
                    count++;
                }
            }
        }
    }
}
