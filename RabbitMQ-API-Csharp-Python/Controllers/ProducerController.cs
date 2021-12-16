using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ_Csharp_Python.Consumer;
using RabbitMQ_Csharp_Python.Publisher;

namespace RabbitMQ_API_Csharp_Python.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IModel _channel;

        public ProducerController(Factory factory)
        {
            _channel = factory.Create();
        }
        [HttpPost(Name = "Sent to Python")]
        public ActionResult Post(Form message)
        {
            new Thread(() => QueueProducer.Publish(_channel,message)).Start();
            new Thread(() => QueueConsumer.Consume(_channel)).Start();

            return Ok();
        }
    }
}
