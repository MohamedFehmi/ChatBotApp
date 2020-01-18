using System;
using ChatBotApp.Helpers;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBotApp
{
    public partial class App : Application
    {
        public static AppCenterHelper appCenterHelper;

        public App()
        {
            InitializeComponent();

            if (appCenterHelper == null)
                appCenterHelper = new AppCenterHelper();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            //App secrets from AppCenter
            string androidAppSecret = "9a1c4006-d975-4786-80b1-0ce86fc419dd";
            string iOSAppSecret = "029038ae-6117-4e21-89c7-8fd71573d27d";

            //Set-up the crash Service
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics), typeof(Push));

            bool didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
                await Current.MainPage.DisplayAlert("Report", "A Crash Report was sent to the developer.", "OK");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
