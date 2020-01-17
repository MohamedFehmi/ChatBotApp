using System;
using System.ComponentModel;
using ChatBotApp.ViewModel.Helpers;
using Xamarin.Forms;

namespace ChatBotApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        BotServiceHelper botServiceHelper;

        public Command SendCommand { get; set; }

        public string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        public MainVM()
        {
            botServiceHelper = new BotServiceHelper();
            SendCommand = new Command(SendActivity);

            //subscribe to message received event
            botServiceHelper.MessageReceived += BotServiceHelper_MessageReceived;
        }

        async void SendActivity()
        {
            await botServiceHelper.SendActivityAsync(Message);
        }

        private void BotServiceHelper_MessageReceived(object sender, Model.BotsResponseEventArgs e)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
