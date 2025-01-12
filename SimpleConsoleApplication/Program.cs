using System.Threading;

static void getData()
{
    Console.WriteLine("Getting data");
}

static void RestoreData()
{
    Console.WriteLine("Restoring data");
}
 static void display()
{
    Console.WriteLine("display function is called...");
}

Console.WriteLine("Hello, World!");

Thread theThread=Thread.CurrentThread;
Console.WriteLine("main thread id: "+theThread.ManagedThreadId);
Thread.Sleep(1000);
Console.WriteLine("display function thread id: "+theThread.ManagedThreadId);
display();

ThreadStart startedThread1=new ThreadStart(getData);
Thread getDataThread=new Thread(startedThread1);
getDataThread.Start();
Thread.Sleep(1000);
Console.WriteLine("getDataThread function thread id: "+getDataThread.ManagedThreadId);


ThreadStart startedThread2=new ThreadStart(RestoreData);
Thread RestoreDataThread=new Thread(startedThread2);
RestoreDataThread.Start();
Thread.Sleep(1000);
Console.WriteLine("displayThread function thread id: "+RestoreDataThread.ManagedThreadId);



