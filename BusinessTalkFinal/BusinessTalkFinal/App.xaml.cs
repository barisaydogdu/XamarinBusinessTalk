using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusinessTalkFinal.Views;
using BusinessTalkFinal.MasterPage;
using BusinessTalkFinal.Helper;

using BusinessTalkFinal.ViewModels.LoginVM;
using BusinessTalkFinal.Views.Desing;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BusinessTalkFinal
{
    public partial class App : Application
    {
        string username = UserSettings.UserName;
        string password = UserSettings.Password;
        LoginViewModel viewModel = new LoginViewModel();
        FirebaseHelper firebaseHelper = new FirebaseHelper();           
        public App()
        { 

            InitializeComponent();         
            if (username == "" && password == "")
            {
                MainPage = new NavigationPage(new LoginTabbed());
            }
            else
            {
                MainPage = new NavigationPage(new MyTabbedPage(username));

            }      
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
