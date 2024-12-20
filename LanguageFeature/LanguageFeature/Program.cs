using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeature
{
    interface IPrintable
    {
        void print();
    }

    class Printer:IPrintable
    {
        void IPrintable.print()
        {
            Console.WriteLine("printing data");
        }
    }
     class CSharpLanguageFeature
    {
        static void Main(string[] args)
        {
            //value type
            //value of value type are stored on stack memory

            //****primatives type
            int count = 10;
            float data = 56.1f;
            bool status=false;

            //reference type
            //values pointed by reference typese are always stored on heap
            //heap is managed by garbage collector

            CSharpLanguageFeature languageFeature=new CSharpLanguageFeature();


            Console.WriteLine("Hello World");

        }
    }
}
