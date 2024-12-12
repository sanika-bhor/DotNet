using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//menu---->debug---->debugproperties-----> write arg int command line argument


namespace CmdArg_Use
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //display arguments using for loop
            Console.WriteLine("using for loop");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("name:{0}", args[i]);
            }

            Console.WriteLine();

            //display arguments using foreach loop
            Console.WriteLine("using foreach loop");
            foreach (string name in args)
            {
                Console.WriteLine("name:{0}",name);
            }

        }
    }
}
