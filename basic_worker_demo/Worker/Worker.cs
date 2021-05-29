using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker
{
    class Worker
    {
        public static void Main(string[] args)
        {
            var queueName = "basic_worker";
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel()){
                channel.QueueDeclare(
                    queue:queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null );
                
                channel.BasicQos(
                    prefetchSize:0,
                    prefetchCount: 1,
                    global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender,  ea) =>{
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [x] Received {message}");

                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);

                    Console.WriteLine( $" [x] Done after {dots*1000} ms");

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple:false);
                };
                channel.BasicConsume(
                    queue: queueName,
                    autoAck: false,
                    consumer: consumer);

                Console.WriteLine(" Press [enter] to exit");
                Console.ReadLine();

            }

        }
    }
}
