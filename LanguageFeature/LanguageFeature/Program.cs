using System;

namespace LanguageFeature
{
    //structure 
     struct Point
    {
        public int x;
        public int y;
    }

    //class
    //Types:
    //          1. abstract:  whose object has not been created
    //          2. concreate: whose object has been created

    abstract class Shape
    {
        public abstract void draw();
        public string color { get; set; }
        public int width { get; set; }

        public void display()
        {
            Console.WriteLine("displaying shape");
        }
    }

    class Line : Shape
    {
        public Point startPoint;
        public Point endPoint;
        
        public override void draw()
        {
            Console.WriteLine("drawing line");
            Console.WriteLine("Starting point: X={0}, Y={1}", startPoint.x, startPoint.y);
            Console.WriteLine("End point: X={0}, Y={1}", endPoint.x, endPoint.y);
            Console.WriteLine("Color: {0}", color);
            Console.WriteLine("Width: {0}", width);
        }
    }
    //prototype
    //all the method of interface must be implementd by its concreate class
    interface IPrintable
    {
        void print();
        void start();
        void stop();
    }

    interface IScannable
    {
        void scanning();
    }

    //prototype is implemented by concreate class
    //concreate class: A class whose object has been created called as concreate class

    //multiple interface inheritance but multiple class inheritance in dotnet is not allowed
    class Printer :IPrintable,IScannable 
    {
        void IPrintable.print()
        {
            Console.WriteLine("printing data");
        }

        void IPrintable.start()
        {
            Console.WriteLine("printer is start");
        }
        void IPrintable.stop()
        {
            Console.WriteLine("printer is stop");
        }

        void IScannable.scanning()
        {
            Console.WriteLine("Scanning printing data");
        }
    }

    class ThreeDPrinter : IPrintable,IScannable
    {
        void IPrintable.print()
        {
            Console.WriteLine("Printing 3D model");
        }
        void IPrintable.start()
        {
            Console.WriteLine("3D Printer is start");
        }

        void IPrintable.stop()
        {
            Console.WriteLine("3D printer is stop");
        }
        void IScannable.scanning()
        {
            Console.WriteLine("Scanning 3D printing model");
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

            //late binding: resolving function at run time
            //early binding: resolving function at compile time

            Console.WriteLine("Interface demo");
            Console.WriteLine();
            IPrintable outpuDevices = null;
            IScannable outpuFeatures = null;

            Console.WriteLine("*** 2D Printer ***");
            Printer printer=new Printer();
            outpuDevices = new Printer();
            outpuFeatures = new Printer();
            
            //late binding
            outpuFeatures.scanning();
            outpuDevices.start();
            outpuDevices.print();
            outpuDevices.stop();
            Console.WriteLine();

            Console.WriteLine("*** 3D Printer ***");
            ThreeDPrinter threeDPrinter = new ThreeDPrinter();
            outpuDevices = new ThreeDPrinter();
            outpuFeatures = new ThreeDPrinter();

            //late binding
            outpuFeatures.scanning();
            outpuDevices.start();
            outpuDevices.print();
            outpuDevices.stop();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Abstract demo");
            Console.WriteLine();

            //Shape shape = new Line();
            Line shape = new Line();
            shape.color = "RED";
            shape.width = 4;
            shape.startPoint.x = 50;
            shape.startPoint.y = 87;
            shape.endPoint.x = 231;
            shape.endPoint.y = 523;

            shape.draw();
            shape.display();

            Console.WriteLine();
            Console.WriteLine("Hello World");

        }
    }
}
