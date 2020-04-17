
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BusinessTalkFinal.Models;
using BusinessTalkFinal.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using BusinessTalkFinal.Helper;
using BusinessTalkFinal.CustomCells;

namespace BusinessTalkFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
            
        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
        SignalrClient client = new SignalrClient();
        ItemsPageViewModel vm;
        ItemsPageViewModel viewModel;
        string _username;
        public ItemDetailPage(ItemsPageViewModel viewModel,string username)
        {
            InitializeComponent();

            BindingContext = vm = new ItemsPageViewModel();
            vm.ListMessages.CollectionChanged += (sender, e) =>
            {
                var target = vm.ListMessages[vm.ListMessages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            };
           
            BindingContext = this.viewModel = viewModel;
            //SİGNALR CONNECTİON
            _username = username;
            this.BindingContext = model;
        }
        private void Client_OnMessageReceived(SignalrUser user)
        {
            model.Add(user);
            vm.ListMessages.Add(user);
        }

        private void Client_ConnectionError()
        {
            DisplayAlert("Connection Error", "Error", "Ok");
        }
        public void MesajGonder()
        {
            SignalrUser item = new SignalrUser();
            client.SendMessagePrivate(_username, txtMessage.Text);        
            txtMessage.Focus();          
            this.BindingContext = model;
        }


        public ItemDetailPage()
        {
            InitializeComponent();         
            MessagesListView.BindingContext=model;     
            BindingContext = this.viewModel = viewModel;       
            BindingContext = viewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MesajGonder();
            BindingContext = vm.ListMessages;
            MessagesListView.BindingContext=model;
        }
    }
}



















//using System;
//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;
//using BusinessTalkFinal.Models;
//using BusinessTalkFinal.ViewModels;
//using BusinessTalkFinal.Helper;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using MvvmHelpers;

//namespace BusinessTalkFinal.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ItemDetailPage : ContentPage
//    {
//        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
//        //IList<Item> model = new ObservableCollection<Item>();
//        SignalrClient client = new SignalrClient();
//        ItemsPageViewModel vm;
//        ItemsPageViewModel viewModel;
//        Item _item = new Item();
//        ItemsPage _page = new ItemsPage();

//        public ItemDetailPage(ItemsPageViewModel viewModel, string username)
//        //public ItemDetailPage(string username)
//        {
//            InitializeComponent();

//            //BindingContext = vm = new ItemsPageViewModel();
//            //vm.ListMessages.CollectionChanged += (sender, e) =>
//            //{
//            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
//            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            //};
//            //_username = username;
//            ////_roomname = groupname;
//            ////_roomname = rooms.id = 1;
//            //client.Connect(_username);
//            //client.ConnectionError += Client_ConnectionError;
//            //client.OnMessageReceived += Client_OnMessageReceived;
//            ////client.OnMessageReceived += Client_OnMessageReceived();
//            ////messagelist.BindingContext = model;
//            //MessagesListView.BindingContext = model;
//            ////_page.ListBind();
//            //this.BindingContext = model;
//            ////BindingContext = this.vm = viewModel;
//            //BindingContext = this.viewModel = viewModel;


//            //BindingContext = vm = new ItemsPageViewModel();
//            //vm.ListMessages.CollectionChanged += (sender, e) =>
//            //{
//            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
//            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            //};
//            //BindingContext = this.viewModel = viewModel;
//            //BindingContext = viewModel;
//            //this.BindingContext = model;
//        }
//        string _username;
//        public ItemDetailPage()
//        {
//            InitializeComponent();


//            //BindingContext = vm = new ItemDetailViewModel();
//            //vm.ListMessages.CollectionChanged += (sender, e) =>
//            //{
//            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
//            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            //};

//            // _username = id;
//            //_roomname = groupname;
//            //_roomname = rooms.id = 1;
//            //client.Connect(_username);
//            //client.ConnectionError += Client_ConnectionError;
//            //client.OnMessageReceived += Client_OnMessageReceived;
//            //MessagesListView.BindingContext = model;
//            //messagelist.BindingContext = model;
//            //_page.ListBind();
//            //this.BindingContext = model;
//            //  this.BindingContext = _rooms;
//        }
//        //  private void Client_OnMessageReceived(SignalrUser user)
//        private void Client_OnMessageReceived(SignalrUser user)
//        {
//            model.Add(user);
//        }

//        private void Client_ConnectionError()
//        {
//            DisplayAlert("Connection Error", "Error", "Ok");
//        }

//        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
//        //{
//        //    //DisplayAlert("Hey", "Deneme", "Cancel");
//        //    client.SendMessagePrivate(_username, txtMessage.Text);
//        //    txtMessage.Text = "";
//        //    txtMessage.Focus();
//        //}
//        public void MesajSendListe()
//        {
//            client.SendMessagePrivate(_username, txtMessage.Text);
//            txtMessage.Text = "";
//            txtMessage.Focus();
//        }
//        public void alert()
//        {
//            DisplayAlert("Deneme", "Hey", "ok");
//        }
//        //IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
//        public ObservableRangeCollection<SignalrUser> ListMessages { get; }
//        ItemDetailPage ıtemDetail = new ItemDetailPage();
//        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
//        {


//            if (!string.IsNullOrEmpty(vm.OutText))
//            {
//                ıtemDetail.MesajSendListe();
//                var message = new SignalrUser
//                {
//                    message = vm.OutText,
//                    IsTextIn = false,
//                    MessageDateTime = DateTime.Now

//                };
//                ListMessages.Add(message);

//            }


//        }
//    }
//}




















//using System;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//using BusinessTalkFinal.Models;
//using BusinessTalkFinal.ViewModels;
//using BusinessTalkFinal.Helper;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;

//namespace BusinessTalkFinal.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ItemDetailPage : ContentPage
//    {
//        ItemsPageViewModel vm;
//        ItemsPageViewModel viewModel;
//        string _username = "baris";
//        string _roomname;
//        Rooms rooms;
//        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
//        SignalrClient client = new SignalrClient();
//        ItemsPage _items = new ItemsPage();
//        ObservableCollection<Rooms> _rooms = new ObservableCollection<Rooms>();
//        public ObservableCollection<Rooms> Rooms { get { return _rooms; } }

//        public ItemDetailPage(ItemsPageViewModel viewModel)
//        {
//            InitializeComponent();

//            BindingContext = vm = new ItemsPageViewModel();
//            vm.ListMessages.CollectionChanged += (sender, e) =>
//            {
//                var target = vm.ListMessages[vm.ListMessages.Count - 1];
//                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            };
//            //BindingContext = this.vm = viewModel;
//            BindingContext = this.viewModel = viewModel;
//        }

//        public ItemDetailPage()
//        {
//                InitializeComponent();
//          //   _username = _username;
//        //    client.ConnectionError += Client_ConnectionError;
//       //     client.OnMessageReceived += Client_OnMessageReceived;
//            //BindingContext = vm = new ItemsPageViewModel();
//            //vm.ListMessages.CollectionChanged += (sender, e) =>
//            //{
//            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
//            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            //};
//        //    _items.ListBind();
//            var item = new Item
//            {
//                PersonId = 1,
//                Name = "1",
//            };
//          //  viewModel = new ItemDetailViewModel(item);
//            BindingContext = viewModel;
//            //this.BindingContext = model;
//            //this.BindingContext = _rooms;
//            ////ChatDesing Binding
//            //BindingContext = vm = new ItemsPageViewModel();
//            //vm.ListMessages.CollectionChanged += (sender, e) =>
//            //{
//            //    var target = vm.ListMessages[vm.ListMessages.Count - 1];
//            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
//            //};
//            //BindingContext = this.viewModel = viewModel;
//            //BindingContext = viewModel;
//        }
//        private void Client_OnMessageReceived(SignalrUser user)
//        {
//            model.Add(user);
//        }

//        private void Client_ConnectionError()
//        {
//            DisplayAlert("Connection Error", "Error", "Ok");
//        }
//        public void SendDataClicked(string messagetxt)
//        {
//            //vm.OutText = txtMessage.Text;
//            client.SendMessagePrivate("Baris",messagetxt);
//            //client.SendMessagePrivate("Baris", txtMessage.Text);
//            txtMessage.Text = "";
//            txtMessage.Focus();

//        }

//    }
//}