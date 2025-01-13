using System.Threading.Tasks;

static async Task GetData()
{
    await Task.Run(()=>
    {
        // some code here
        Thread theThread=Thread.CurrentThread;
        Console.WriteLine("getting Data....");
        Console.WriteLine("GetData thread id: "+theThread.ManagedThreadId);
    });
}

static async Task RestoreData()
{
    await Task.Run(()=>{
        // some code here
        Thread theThread = Thread.CurrentThread;
        Console.WriteLine("Restoring Data....");
        Console.WriteLine("GetData thread id: " + theThread.ManagedThreadId);

    });
}

Console.WriteLine("Hello, World!");
GetData();
RestoreData();
