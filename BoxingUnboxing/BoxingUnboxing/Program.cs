using System;

namespace BoxingUnboxing
{
     class Program
    {
        static void Main(string[] args)
        {

            //value type
            int count = 8;
            Console.WriteLine("value type variable - count: {0}",count);


            //reference type
            //object is a root classs for all the classes
            Object obj=new object();

            //boxining is a technique of converting the value type variable to refernce type
            obj = count;
            Console.WriteLine("reference type object - obj: {0}", obj);

            //unboxing is a technique of converting the refernce type object to value type by the explicit type casting
            int unboxingCount = (int)obj;
            Console.WriteLine("value type variable - unboxingCount: {0}", unboxingCount);
        }
    }
}
