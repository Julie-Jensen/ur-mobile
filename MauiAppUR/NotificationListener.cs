using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using NotificationUR;
using System.Text.Json;

namespace MauiAppUR
{
    public class NotificationListener
    {
        public static void ListenOnQueue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "robot_notification", type: ExchangeType.Direct);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(
                        queue: queueName,
                        exchange: "robot_notification",
                        routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        Console.WriteLine("message received)");
                        var body = ea.Body.ToArray();
                        var jsonString = Encoding.UTF8.GetString(body);
                        var robotObj = JsonSerializer.Deserialize<NotificationData>(jsonString);
                    };

                    channel.BasicConsume(
                        queue: queueName,
                        autoAck: true,
                        consumer: consumer);
                }
            }
        }
    }
}
