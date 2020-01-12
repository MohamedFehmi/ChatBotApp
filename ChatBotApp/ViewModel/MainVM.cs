using System;
using ChatBotApp.ViewModel.Helpers;

namespace ChatBotApp.ViewModel
{
    public class MainVM
    {
        BotServiceHelper botServiceHelper;

        public MainVM()
        {
            botServiceHelper = new BotServiceHelper();
        }
    }
}
