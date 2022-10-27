using System.Globalization;
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
            Console.WriteLine($"\nCobot name: {notificationData.Robot.Name}\nStatus: {notificationData.Robot.Status}");
            updatesEmitter.Emit(notificationData);
        }

        public NotificationData CreateNotificationDataObj(RobotObjMyUr robotObjMyUr)
        {
            return new NotificationData()
            {
                Robot = new Robot()
                {
                    Id = Convert.ToInt32(robotObjMyUr.Id),
                    Name = robotObjMyUr.Name,
                    Model = robotObjMyUr.Model,
                    Year = Convert.ToDateTime(robotObjMyUr.InstalledDate, cultureInfoUS).Year,
                    Status = robotObjMyUr.Status,
                    StatusChangedDate = Convert.ToDateTime(robotObjMyUr.StatusChangedDate, cultureInfoUS)
                }
            };
        }
    }
}
