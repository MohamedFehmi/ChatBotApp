using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace ChatBotApp.Helpers
{
    public class AppCenterHelper
    {
        public async Task TrackEvent(Dictionary<string, string> properties)
        {
            if (await Analytics.IsEnabledAsync())
                Analytics.TrackEvent("Message_Sent", properties);
        }

        public async Task TrackError(Exception ex, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
                Crashes.TrackError(ex, properties);
        }
    }
}
