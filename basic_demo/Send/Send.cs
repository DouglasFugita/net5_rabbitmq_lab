using System;
using System.Text;
using RabbitMQ.Client;

namespace Send
{
    class Send
    {
        public static void Main(string[] args)
        {
            var queueName = "demo";

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var totalMsg = 10;

                for (var i = 0; i < totalMsg; i++)
                {
                    string message = $"Hello Basic Demo! Message: {i+1}/{totalMsg}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queueName,
                        basicProperties: null,
                        body: body
                        );

                    Console.WriteLine(" [x] Sent {0}", message);
                }


            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
