using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ_API_Csharp_Python;

namespace RabbitMQ_Csharp_Python.Publisher
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel,Form message )
        {
            channel.QueueDeclare("CsharpToPython",true,false,false,null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish("", "CsharpToPython", null, body);


        }
    }
}
