using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace MyURPrototype
{
    public class UpdatesEmitter
    {
        public void Emit(RobotUpdate robotUpdate)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "robot_updates", type: ExchangeType.Direct);

                    var props = channel.CreateBasicProperties();
                    props.DeliveryMode = 2; // persistent delivery

                    var serializedData = JsonSerializer.Serialize(robotUpdate);
                    var body = Encoding.UTF8.GetBytes(serializedData);

                    channel.BasicPublish(
                        exchange: "robot_updates",
                        routingKey: "",
                        basicProperties: null,
                        body: body);

                    Console.WriteLine($"\n{serializedData}");
                }
            }
        }        
    }
}
