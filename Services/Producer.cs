using Confluent.Kafka;
using Kafka.Producer.Config;

namespace Kafka.Producer.Services
{
    public class Producer
    {
        private readonly KafkaConfiguration _kafkaConfiguration;

        public Producer(KafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
        }

        public void ProduceMessage(string topic, string message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _kafkaConfiguration.BootstrapServers
            };

            Console.WriteLine($"BootstrapServers {_kafkaConfiguration.BootstrapServers}");

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine($"Started Produce message to Kafka to Topic {topic}");

                var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).Result;

                Console.WriteLine($"Delivered message to {deliveryReport.TopicPartitionOffset}");
            }
        }
    }
}
