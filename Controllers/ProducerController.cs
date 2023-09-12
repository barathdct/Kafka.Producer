using Kafka.Producer.Config;
using Kafka.Producer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kafka.Producer.Controllers
{
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly Services.Producer _kafkaProducer;
        private readonly KafkaConfiguration _kafkaConfiguration;

        public ProducerController(Services.Producer kafkaProducer, KafkaConfiguration kafkaConfiguration)
        {
            _kafkaProducer = kafkaProducer;
            _kafkaConfiguration = kafkaConfiguration;
        }

        [HttpPost]
        [Route("/ProduceMessage")]
        public string ProduceMessage([FromBody] Request request)
        {
            System.Console.WriteLine("Called Procduce Message and Request Message - " + request.Message);
            _kafkaProducer.ProduceMessage(_kafkaConfiguration.TopicName!, request.Message!);
            return "Success";
        }
    }
}