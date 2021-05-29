using System;
using System.Text;
using RabbitMQ.Client;

namespace NewTask
{
    class NewTask
    {
        public static void Main(string[] args)
        {
            var queueName = "basic_worker";

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var totalMsg = 10;

                for (int i = 0; i < totalMsg; i++)
                {
                    var message = GetMessage(i+1);
                    var body = Encoding.UTF8.GetBytes(message);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queueName,
                        basicProperties: properties,
                        body: body
                    );

                    Console.WriteLine($"[x] Sent {message}");
                }
            }

        }
        private static string GetMessage(int i)
        {
            return $"Message {i}"+"".PadLeft(i,'.') ;
        }
    }
}
