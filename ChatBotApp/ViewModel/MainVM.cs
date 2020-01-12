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
        }

        async void SendActivity()
        {
            await botServiceHelper.SendActivityAsync(Message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
