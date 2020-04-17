using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BusinessTalkFinal.Models;
using BusinessTalkFinal.Helper;

namespace BusinessTalkFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        ItemsPage page;
       
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            Item = new Item
            {
                PersonId = 1,
                Name = "This is an item description."
            };
            BindingContext = this;
        }
        Item _item = new Item();
     
        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {  
            String myDate = DateTime.Now.ToString();        
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text/*, *//*_item.ToString()*/, myDate);          
            txtName.Text = string.Empty;
            await DisplayAlert("Başarılı", "Oda Eklendi", "OK");      
            await Navigation.PopModalAsync();
        }
        public async void Save_Clicked(object sender, EventArgs e)
        {         
            String myDate = DateTime.Now.ToString(); 
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text/*, /*_item.ToString()*/, myDate);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;      
            await DisplayAlert("Başarılı", "Ayarlar Değiştirildi.", "OK");         
            await Navigation.PopModalAsync();
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtId.Text));
            if (person != null)
            {
                txtId.Text = person.PersonId.ToString();
                txtName.Text = person.Name;
                await DisplayAlert("Başarılı", "Oda Getirildi. ", "OK");

            }
            else
            {
                await DisplayAlert("Hata", "Oda Bulunamadı", "OK");
            }
        }

        public async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Başarılı", "Oda Güncellendi", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();   
        }
        public async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
            await DisplayAlert("Başarılı", "Oda Silindi!", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();         
        }
    }
}