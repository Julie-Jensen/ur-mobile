using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using NotificationUR;

namespace NotificationSystemUR
{
    public class NotificationEmitter
    {
        public void Emit(NotificationData notificationData)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "robot_notification", type: ExchangeType.Direct);

                    var props = channel.CreateBasicProperties();
                    props.DeliveryMode = 2; // persistent delivery

                    var serializedData = JsonSerializer.Serialize(notificationData);
                    var body = Encoding.UTF8.GetBytes(serializedData);

                    channel.BasicPublish(
                        exchange: "robot_notification",
                        routingKey: "",
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }
}
