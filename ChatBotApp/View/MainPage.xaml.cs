using System;
using System.Collections.Generic;
using System.ComponentModel;
using ChatBotApp.ViewModel;
using Xamarin.Forms;

namespace ChatBotApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainVM mainVM;

        public MainPage()
        {
            InitializeComponent();

            mainVM = Resources["vm"] as MainVM;

            mainVM.Messages.CollectionChanged += Messages_CollectionChanged;
        }

        private void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var newMessage = mainVM.Messages[mainVM.Messages.Count - 1];
            Device.BeginInvokeOnMainThread(()=>
            {
                chatListView.ScrollTo(newMessage, ScrollToPosition.End, true);
            });
        }
    }
}