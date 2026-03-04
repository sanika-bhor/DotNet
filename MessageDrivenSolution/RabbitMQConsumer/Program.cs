using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("");


var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare(queue:"hello",durable:false,exclusive:false,autoDelete:false,arguments:null);

var consumer=new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body=ea.Body.ToArray();
    var msg=Encoding.UTF8.GetString(body);
    Console.WriteLine($"[x] received {msg}");
};

channel.BasicConsume(queue:"hello",autoAck:true,consumer:consumer);
Console.WriteLine("waiting for incoming msg from RabbitMQ service");

Console.WriteLine("press [enter] to exit");
Console.ReadLine();

