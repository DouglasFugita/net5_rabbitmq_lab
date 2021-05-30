using System;
using System.Text;
using RabbitMQ.Client;

namespace EmitLog
{
    class EmitLog
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var totalMsg = 10;

                for (int i = 0; i < totalMsg; i++)
                {
                    var message = GetMessage(i + 1);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                        exchange: "logs",
                        routingKey: "",
                        basicProperties: null,
                        body: body
                        );
                    
                    Console.WriteLine($" [x] Sent {message}");
                }

                Console.WriteLine(" Press [enter] to exit");
                Console.ReadLine();
            }
        }

        private static string GetMessage(int i)
        {
            return $"Message {i}" + "".PadLeft(i, '.');
        }
    }
}
