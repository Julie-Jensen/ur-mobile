using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationSystemUR
{
    public static class MyURListener
    {
        private static readonly NotificationHandler notificationHandler = new NotificationHandler();

        public static void ListenOnQueue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "robot_updates", type: ExchangeType.Direct);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(
                        queue: queueName,
                        exchange: "robot_updates",
                        routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var jsonString = Encoding.UTF8.GetString(body);
                        var robotObj = JsonSerializer.Deserialize<RobotObjMyUr>(jsonString);

                        notificationHandler.EmitNotification(robotObj);
                    };

                    channel.BasicConsume(
                        queue: queueName,
                        autoAck: true,
                        consumer: consumer);

                    Console.ReadLine();
                }
            }
        }
    }
}
