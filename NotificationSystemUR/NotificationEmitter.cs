using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using NotificationUR;
using Newtonsoft.Json;
using NotificationSystemUR.Models;
using System.Net.Http.Headers;

namespace NotificationSystemUR
{
    public class NotificationEmitter
    {
        public async void Emit(PushNotificationRequest pushNotificationRequest)
        {
            var url = "https://fcm.googleapis.com/fcm/send";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + "");

                string serializedRequest = JsonConvert.SerializeObject(pushNotificationRequest);

                var response = await client.PostAsync(url, new StringContent(serializedRequest, Encoding.UTF8, "application/json"));

                Console.WriteLine(response.StatusCode.ToString());
            }
        }
    }
}
