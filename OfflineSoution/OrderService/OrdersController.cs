using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using OrderEntity;
using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OrderService
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        [HttpPost("place")]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            var factory=new ConnectionFactory(){ HostName = "localhost", UserName = "guest", Password = "guest" };
            using var connection=factory.CreateConnection();
            using var channel=connection.CreateModel();

            channel.QueueDeclare(queue:"orderQueue",durable: true, exclusive:false,autoDelete:false,arguments:null);

            

            var message=JsonSerializer.Serialize(order);
            var body=Encoding.UTF8.GetBytes(message);
            

            channel.BasicPublish(exchange:"",routingKey:"orderQueue",basicProperties:null,body:body);
        
        return Ok("order placed successfully");
        }
    }
}