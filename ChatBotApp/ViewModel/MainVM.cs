using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ChatBotApp.Model;
using ChatBotApp.ViewModel.Helpers;
using Xamarin.Forms;

namespace ChatBotApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        BotServiceHelper botServiceHelper;

        //Commands
        public Command SendCommand { get; set; }

        //Properties
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

        public ObservableCollection<ChatMessage> Messages { get; set; }

        public MainVM()
        {
            botServiceHelper = new BotServiceHelper();
            SendCommand = new Command(SendActivity);
            Messages = new ObservableCollection<ChatMessage>();
            //subscribe to message received event
            botServiceHelper.MessageReceived += BotServiceHelper_MessageReceived;
        }

        async void SendActivity()
        {
            Messages.Add(new ChatMessage
            {
                Text = Message,
                IsInComing = false
             });
            await botServiceHelper.SendActivityAsync(Message);
            Message = string.Empty;
        }

        private void BotServiceHelper_MessageReceived(object sender, Model.BotsResponseEventArgs e)
        {
            foreach (var activity in e.Activities)
            {
                if (activity.From.Id != "user1")
                {
                    Messages.Add(new ChatMessage {
                        Text = activity.Text,
                        IsInComing = true
                    });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
