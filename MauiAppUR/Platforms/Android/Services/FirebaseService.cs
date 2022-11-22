using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract;

namespace MauiAppUR.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService()
        {
        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            var deviceTokenPref = "DeviceToken";

            if (Preferences.ContainsKey(deviceTokenPref))
                Preferences.Remove(deviceTokenPref);

            Preferences.Set(deviceTokenPref, token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();

            SendNotification(notification.Title, notification.Body, message.Data);
        }

        private void SendNotification(string title, string messageBody, IDictionary<string, string> data)
        {
            var rand = new Random();
            var notificationId = rand.Next(0, 1000);

            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);

            foreach (var key in data.Keys)
            {
                string value = data[key];
                intent.PutExtra(key, value);
            }

            var pendingIntent = PendingIntent.GetActivity(this, notificationId, intent, PendingIntentFlags.Immutable);

            // Passing current context (this) and channel ID to the builder.
            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Mipmap.appicon)
                .SetContentText(messageBody)
                .SetChannelId(MainActivity.CHANNEL_ID)
                .SetContentIntent(pendingIntent)
                .SetPriority(3);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(notificationId, notificationBuilder.Build());
        }
    }
}
