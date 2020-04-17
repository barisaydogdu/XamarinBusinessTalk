using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessTalkFinal.Models
{
    public class SignalrUser : ObservableObject
    {
        public string username { get; set; }
        public string message { get; set; }
         public string groupname { get; set; }

        public DateTime MessageDateTime
        {
            get { return _messageDateTime; }
            set { SetProperty(ref _messageDateTime, value); }
        }

        DateTime _messageDateTime;

        public string TimeDisplay => MessageDateTime.ToLocalTime().ToString();

        public bool IsTextIn
        {
            get { return _isTextIn; }
            set { SetProperty(ref _isTextIn, value); }
        }
        bool _isTextIn;
    }
}