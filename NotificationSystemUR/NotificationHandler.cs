using System.Globalization;
using NotificationSystemUR.Models;
using NotificationUR;

namespace NotificationSystemUR
{
    public class NotificationHandler
    {
        private readonly CultureInfo cultureInfoUS = CultureInfo.GetCultureInfo("en-US");
        private readonly NotificationEmitter updatesEmitter = new NotificationEmitter();

        public void EmitNotification(RobotObjMyUr robotObjMyUr)
        {
            var notificationData = CreateNotificationDataObj(robotObjMyUr);
            Console.WriteLine($"\nCobot name: {notificationData.data["name"]}\nStatus: {notificationData.data["status"]}");
            updatesEmitter.Emit(notificationData);
        }

        public PushNotificationRequest CreateNotificationDataObj(RobotObjMyUr robotObjMyUr)
        {
            return new PushNotificationRequest()
            {
                notification = new NotificationMessage()
                {
                    title = $"'{robotObjMyUr.Name}' status update",
                    body = $"New status: '{robotObjMyUr.Status}' on {robotObjMyUr.StatusChangedDate}"
                },
                data = new Dictionary<string, string>() 
                { 
                    { "id", robotObjMyUr.Id },
                    { "name", robotObjMyUr.Name },
                    { "model", robotObjMyUr.Model },
                    { "year", Convert.ToDateTime(robotObjMyUr.InstalledDate, cultureInfoUS).Year.ToString() },
                    { "status", robotObjMyUr.Status },
                    { "statusChangedDate", robotObjMyUr.StatusChangedDate}
                },
                registration_ids = new List<string>() { "" }
            };
        }
    }
}
