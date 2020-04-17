using BusinessTalkFinal.Helper;
using BusinessTalkFinal.ViewModels.LoginVM;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessTalkFinal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
        }
        WelcomePageVM welcomePageVM;
        string _email;
        public WelcomePage (string email)
		{
            InitializeComponent();
            welcomePageVM = new WelcomePageVM(email);
            BindingContext = welcomePageVM;
            _email = email;
           
        }
        public string value;      
        private void Changepass_Clicked(object sender, EventArgs e)
        {
            passq.IsVisible = true;
            updatebtn.IsVisible = true;
        }

        public string localhostq;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private async void Btnlocal_Clicked(object sender, EventArgs e)
        {
            
            try
            {              
            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Local Eklenemedi", "OK");

            }        
        }

        private void Deletebtnq_Clicked(object sender, EventArgs e)
        {
            entrydelete.IsVisible = true;
            deleteq.IsVisible = true;
        }
    }
}