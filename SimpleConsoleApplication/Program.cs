using System.Threading;



Console.WriteLine("Hello, World!");
Thread theThread=Thread.CurrentThread;
Console.WriteLine("main thread id: "+theThread.ManagedThreadId);
Thread.Sleep(5000);
Console.WriteLine("display function thread id: "+theThread.ManagedThreadId);
display();


 static void display()
{
    Console.WriteLine("display function is called...");
}