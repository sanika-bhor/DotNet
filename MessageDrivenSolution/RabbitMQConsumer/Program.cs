using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQConsumer
{

public class Program
{
    var factory=new ConnectionFactory(){ HostName="localhost" };

    using var connection=factory.CreateConnection();

}
}