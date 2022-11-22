using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystemUR.Models
{
    public class PushNotificationRequest
    {
        public List<string> registration_ids { get; set; } = new List<string>();
        public NotificationMessage notification { get; set; }
        public Dictionary<string, string> data { get; set; }
    }
}
