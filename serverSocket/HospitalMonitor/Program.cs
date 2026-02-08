using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets();

var clients = new List<WebSocket>();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var socket = await context.WebSockets.AcceptWebSocketAsync();
        clients.Add(socket);

        Console.WriteLine("Client Connected");

        await Listen(socket, clients);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

_ = Task.Run(async () =>
{
    while (true)
    {
        var data = GeneratePatientData();

        var json = JsonSerializer.Serialize(data);
        var bytes = Encoding.UTF8.GetBytes(json);

        await Broadcast(bytes, clients);

        await Task.Delay(2000);
    }
});

app.Run();


// ---------------- Helper Methods ----------------

async Task Broadcast(byte[] data, List<WebSocket> clients)
{
    foreach (var client in clients.ToList())
    {
        if (client.State == WebSocketState.Open)
        {
            await client.SendAsync(
                data,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }
}

async Task Listen(WebSocket socket, List<WebSocket> clients)
{
    var buffer = new byte[1024];

    try
    {
        while (socket.State == WebSocketState.Open)
        {
            await socket.ReceiveAsync(buffer, CancellationToken.None);
        }
    }
    finally
    {
        clients.Remove(socket);
    }
}

PatientData GeneratePatientData()
{
    var rand = new Random();

    return new PatientData
    {
        PatientId = "P1023",
        HeartRate = rand.Next(60, 100),
        Oxygen = rand.Next(95, 100),
        Status = "Stable",
        Time = DateTime.Now
    };
}

// ---------------- Model ----------------

class PatientData
{
    public string PatientId { get; set; }
    public int HeartRate { get; set; }
    public int Oxygen { get; set; }
    public string Status { get; set; }
    public DateTime Time { get; set; }
}