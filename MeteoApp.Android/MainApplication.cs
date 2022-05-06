using System;
using Newtonsoft.Json.Linq;
using Android.App;
using Android.Runtime;
using Plugin.FirebasePushNotification;
using Plugin.LocalNotifications;

namespace MeteoApp.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            FirebasePushNotificationManager.Initialize(this, true);

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                CrossLocalNotifications.Current.Show("title", string.Join(Environment.NewLine, p.Data));
            };
        }
    }
}