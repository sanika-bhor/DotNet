using System.Threading;

static void getData()
{
    
    Console.WriteLine("Getting data");
    Thread theThread = Thread.CurrentThread;
    Console.WriteLine("GetData thread id: " + theThread.ManagedThreadId);
}

static void RestoreData()
{
    Thread theThread = Thread.CurrentThread;
    Console.WriteLine("restoreData thread id: " + theThread.ManagedThreadId);
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
display();
Console.WriteLine("display function thread id: " + theThread.ManagedThreadId);

Thread.Sleep(1000);

ThreadStart startedThread1 =new ThreadStart(getData);
Thread getDataThread=new Thread(startedThread1);
getDataThread.Start();
Console.WriteLine("getDataThread function thread id: "+getDataThread.ManagedThreadId);

Thread.Sleep(1000);

ThreadStart startedThread2 =new ThreadStart(RestoreData);
Thread RestoreDataThread=new Thread(startedThread2);
RestoreDataThread.Start();
Console.WriteLine("displayThread function thread id: "+RestoreDataThread.ManagedThreadId);
