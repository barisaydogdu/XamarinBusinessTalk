using System;
using System.Windows.Input;
using BusinessTalkFinal.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}



//        public ObservableRangeCollection<Message> ListMessages { get; }
//        public ICommand SendCommand { get; set; }

//        public ItemDetailViewModel()
//        {
//            ListMessages = new ObservableRangeCollection<Message>();

//            SendCommand = new Command(() =>
//            {
//                if (!String.IsNullOrWhiteSpace(OutText))
//                {
//                    var message = new Message
//                    {
//                        Text = OutText,
//                        IsTextIn = false,
//                        MessageDateTime = DateTime.Now
//                    };


//                    ListMessages.Add(message);
//                    OutText = "";
//                }

//            });

//        }


//        public string OutText
//        {
//            get { return _outText; }
//            set { SetProperty(ref _outText, value); }
//        }
//        string _outText = string.Empty;
//    }
//}