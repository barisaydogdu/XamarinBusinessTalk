using BusinessTalkFinal.Models;
using BusinessTalkFinal.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels
{
    public class ItemsPageViewModel : BaseViewModel
    {
        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
        ItemDetailPage _page = new ItemDetailPage();
        public ObservableRangeCollection<SignalrUser> ListMessages { get; }
        //public   IList<SignalrUser> ListMessages { get; }
        public ICommand SendCommand { get; set; }
        
        public ItemsPageViewModel(Item item = null)
        {
            ListMessages = new ObservableRangeCollection<SignalrUser>();

            SendCommand = new Command(() =>
            {


                if (!String.IsNullOrWhiteSpace(OutText))
                {

                    var _messageq = new SignalrUser()
                    {
                        message = OutText,
                        IsTextIn = true,
                        MessageDateTime = DateTime.Now

                    };


                    ListMessages.Add(_messageq);
                    OutText = "";
                    _page.MesajGonder();
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