using BusinessTalkFinal.Helper;
using BusinessTalkFinal.Models;
using BusinessTalkFinal.ViewModels.LoginVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessTalkFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chat : ContentPage
    {

        public  string _username;
        string _roomname;      
        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
        SignalrClient client = new SignalrClient();
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        ObservableCollection<Rooms> _rooms = new ObservableCollection<Rooms>();
        private string v;
        LoginViewModel loginViewModel;
        public ObservableCollection<Rooms> Rooms { get { return _rooms; } }
        Item _item = new Item();

        public Chat(string username, string ıd)
        {
            InitializeComponent();
            BindingContext = loginViewModel;
            Title = ıd;
            _username = username;
            _roomname = ıd;
            client.Connect(_username, _roomname);
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;  
            messagelist.BindingContext = model;
            this.BindingContext = model;
            this.BindingContext = _rooms;
            BindMessage();
          
        }
        SignalrUser user = new SignalrUser();


        private void Client_OnMessageReceived(SignalrUser user)
        {
            model.Add(user);
        }

        private void Client_ConnectionError()
        {
            DisplayAlert("Hata", "Bağlantı Hatası", "OK");
        }
        LoginViewModel loginmodel;
        private async void Btnsend_Clicked(object sender, EventArgs e)
        {
            //FİREBASE KAYDET
            try
            {
                Item _item = new Item();
                Users usermodel = new Users();
                GroupMessage();
                await firebaseHelper.AddMessage(_username, txtMessage.Text, _roomname);
                txtMessage.Text = string.Empty;                     
            }
            catch (Exception)
            {
                DisplayAlert("Hata", "Mesaj gönderilemedi.İnternet Bağlantınızı Kontrol Ediniz!", "OK");
            }
       
        }

        public async void BindMessage()
        {
            while (true)
            {
                var allPersons = await firebaseHelper.GetAllMessage(_roomname);
                messagelist.ItemsSource = allPersons;
            }                    
        }    
        public void AllMessage()
        {
            client.SendMessagePrivate(_username, txtMessage.Text);
            txtMessage.Text = "";
            txtMessage.Focus();
        }
        public void GroupMessage()
        {
            Item item = new Item();        
            client.SendMessage(_username, txtMessage.Text,_roomname);
        }           
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                client.AddToRoom(_roomname);
                DisplayAlert("Başarılı", "Odaya Başarıyla Katıldınız!", "OK");
              //  BindMessage();
            }
            catch (Exception)
            {

                DisplayAlert("Uyarı", "Lütfen Odaya Katılmadan Önce Bekleyiniz!", "OK");
            }             
        }

        private async void Send_Tapped(object sender, EventArgs e)
        {
            //FİREBASE KAYDET
            try
            {
                Item _item = new Item();
                Users usermodel = new Users();
                GroupMessage();
                await firebaseHelper.AddMessage(_username, txtMessage.Text, _roomname);
                txtMessage.Text = string.Empty;              
                BindMessage();
               
            }
            catch (Exception)
            {
                DisplayAlert("Hata!", "Mesaj gönderilemedi.", "OK");
            }         
        }
    }
}