using BusinessTalkFinal.Helper;
using BusinessTalkFinal.Models;
using BusinessTalkFinal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.LoginVM
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string isim;
        public string Isim
        {
            get { return isim; }
            set
            {
                isim = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Isim"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new SignUpPage()); });
            }
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Hata", "Lütfen Email ve Parola Giriniz!", "OK");
            else
            {             
                var user = await FirebaseHelper.GetUser(Email);              
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {
                        UserSettings.UserName = Email;
                        UserSettings.Password = Password;                 
                        await App.Current.MainPage.Navigation.PushAsync(new MyTabbedPage(Email));                    
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Giriş Başarısız", "Girdiğiniz Email ve Parola Doğru Değil!", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Giriş Başarısız", "Kullanıcı Bulunamadı", "OK");
            }
        }
    }
}
