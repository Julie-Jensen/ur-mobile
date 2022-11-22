using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Java.Lang;

namespace MauiAppUR;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    internal static readonly string CHANNEL_ID = "TestChannel";
    internal static int NOTIFICATION_ID = 101;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        if (Intent.Extras != null)
        {
            foreach (var key in Intent.Extras.KeySet())
            {
                if (key == "NavId")
                {
                    string idVal = Intent.Extras.GetString(key);

                    if (Preferences.ContainsKey(idVal))
                        Preferences.Remove(idVal);

                    Preferences.Set(idVal, idVal);
                }
            }
        }

        CreateNotificationChannel();
    }

    private void CreateNotificationChannel()
    {
        if (OperatingSystem.IsOSPlatformVersionAtLeast("android", 26))
        {
            var channel = new NotificationChannel(CHANNEL_ID, "Test Notification Channel", NotificationImportance.Default);
            var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);

            notificationManager.CreateNotificationChannel(channel);
        }
    }
}
