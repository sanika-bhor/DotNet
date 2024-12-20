using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeature
{
    //prototype
    interface IPrintable
    {
        void print();
    }

    //prototype is implemented by concreate class
    //concreate class: A class whose object has been created called as concreate class
    class Printer:IPrintable
    {
        void IPrintable.print()
        {
            Console.WriteLine("printing data");
        }
    }

    class ThreeDPrinter : IPrintable 
    {
        void IPrintable.print()
        {
            Console.WriteLine("Printing 3D model");
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
            IPrintable outpuDevices = null;

            Printer printer=new Printer();
            outpuDevices = new Printer();
            outpuDevices.print();

            ThreeDPrinter threeDPrinter= new ThreeDPrinter();
            outpuDevices = new ThreeDPrinter();
            outpuDevices.print();



            Console.WriteLine("Hello World");

        }
    }
}
