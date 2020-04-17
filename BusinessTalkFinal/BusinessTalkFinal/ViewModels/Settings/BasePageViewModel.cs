using BusinessTalkFinal.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.Settings
{
    public class BasePageViewModel : INotifyPropertyChanged
    {
        public INavigation _navigation;
        public string UserName
        {
            get => UserSettings.UserName;
            set
            {
                UserSettings.UserName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get => UserSettings.Password;
            set
            {
                UserSettings.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}