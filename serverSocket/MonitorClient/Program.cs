using System.Net.WebSockets;
using System.Text;

var socket = new ClientWebSocket();

await socket.ConnectAsync(
    new Uri("ws://localhost:5029/ws"),
    CancellationToken.None);

Console.WriteLine("Connected to Server");

var buffer = new byte[1024];

while (socket.State == WebSocketState.Open)
{
    var result = await socket.ReceiveAsync(buffer, CancellationToken.None);

    var message = Encoding.UTF8.GetString(
        buffer, 0, result.Count);

    Console.WriteLine("Patient Update:");
    Console.WriteLine(message);
    Console.WriteLine("---------------------");
}