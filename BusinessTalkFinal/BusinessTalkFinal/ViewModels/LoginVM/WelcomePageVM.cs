using BusinessTalkFinal.Helper;
using BusinessTalkFinal.Views;
using BusinessTalkFinal.MasterPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.LoginVM
{
    public class WelcomePageVM : INotifyPropertyChanged
    {
        public WelcomePageVM(string email2)
        {
            Email = email2;
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
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
        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }

        public Command DeleteCommand
        {
            get { return new Command(Delete); }
        }
    
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    UserSettings.ClearAllData();

               
                    App.Current.MainPage.Navigation.PushAsync(new LoginTabbed());
                });
            }
        }
     
        WelcomePage welcomePage = new WelcomePage();
        private async void Update()
        {

            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FirebaseHelper.UpdateUser(Email, Password);
                    if (isupdate)
                        await App.Current.MainPage.DisplayAlert("Başarılı", "Şifre Değiştirildi", "Ok");

                    else
                        await App.Current.MainPage.DisplayAlert("Hata", "Şifre Değiştirme Başarısız", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Şifre Gerekli", "Lütfen Bir Parola Giriniz", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        } 

        private async void Delete()
        {

            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı","Hesabı Silmek Üzeresiniz Emin Misiniz","Tamam");
                    var isdelete = await FirebaseHelper.DeleteUser(Email, Password);
                    if (isdelete)
                    await App.Current.MainPage.Navigation.PushAsync(new MasterPage.LoginTabbed());               
                    else
                        await App.Current.MainPage.DisplayAlert("Hata", "Kayıt Silinemedi", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Şifre Gerekli", "Lütfen Bir Parola Giriniz", "OK");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
    }
}
