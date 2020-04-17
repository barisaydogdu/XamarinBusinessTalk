using BusinessTalkFinal.Helper;
using BusinessTalkFinal.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.LoginVM
{
    public class SignUpVM : INotifyPropertyChanged
    {
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
        public string isim;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        App.Current.MainPage.DisplayAlert("Hata", "Girilen Parola Eşleşmiyor!", "OK");
                });
            }
        }
        private async void SignUp()
        {
            SignUpPage signUpPage = new SignUpPage();         
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Hata", "Lütfen Email ve Parola Giriniz!", "OK");
            var emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            if (!String.IsNullOrWhiteSpace(email) && !(Regex.IsMatch(Email, emailPattern)))
                await App.Current.MainPage.DisplayAlert("Hata", "Geçersiz Email", "OK");
            else
            {          
                var user = await FirebaseHelper.AddUser(Email, Password);              
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Başarılı", "Kayıt Başarılı", "Ok");
                 
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());                  
                }                               
                    else
                    await App.Current.MainPage.DisplayAlert("Hata", "Kayıt Başarısız!", "OK");
                }
                }
            }
        }
    
