using RabbitMQ.Client;

namespace RabbitMQ_API_Csharp_Python;

public class Factory
{
    public IModel Create()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        return channel;     

    }
}

public class Form
{
    public string? Name { get; set; } 
    public string? Message { get; set; }
}