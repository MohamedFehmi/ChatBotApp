using System;
using System.Collections.Generic;

namespace ChatBotApp.Model
{
    public class BotsResponseEventArgs : EventArgs
    {
        public List<Activity> Activities { get; set; }
    }
}
