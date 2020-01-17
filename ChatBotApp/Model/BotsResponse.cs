using System;
using System.Collections.Generic;

namespace ChatBotApp.Model
{
    public class BotsResponse
    {
		public string Watermark { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
