using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppUR.Models
{
    public class PushNotificationRequest
    {
        public List<string> registration_ids { get; set; } = new List<string>();
        public NotificationMessage notification { get; set; }
        public object data { get; set; }
    }
}
