using System.Threading.Tasks;

static async Task getData()
{
    await Task.Run(()=>
    {
        // some code here
        Console.WriteLine("getting Data....");
    });
}


Console.WriteLine("Hello, World!");
