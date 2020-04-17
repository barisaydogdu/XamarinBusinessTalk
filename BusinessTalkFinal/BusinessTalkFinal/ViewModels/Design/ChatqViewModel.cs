using BusinessTalkFinal.Helper;
using BusinessTalkFinal.Models;
using BusinessTalkFinal.Views;
using Microsoft.AspNet.SignalR.Client;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels
{
    public class ChatqViewModel : BaseViewModel
    {
        public ObservableRangeCollection<SignalrUser> ListMessages { get; }
        public ICommand SendCommand { get; set; }
        private HubConnection hubConnection;
        public Command SendMessageCommand { get; }
        SignalrClient client;
       
        public ChatqViewModel()
        {
            ListMessages = new ObservableRangeCollection<SignalrUser>();

            SendCommand = new Command(() =>
            {
                if (!String.IsNullOrWhiteSpace(OutText))
                {            
                    var messageq = new SignalrUser
                    {
                        message = OutText,
                        IsTextIn = false,
                        MessageDateTime = DateTime.Now
                    };
                    ListMessages.Add(messageq);
                    OutText = "";
                }

            });
        }
        public string OutText
        {
            get { return _outText; }
            set { SetProperty(ref _outText, value); }
        }
        string _outText = string.Empty;
    }
}
