using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BusinessTalkFinal.Models;
using BusinessTalkFinal.Views;
using BusinessTalkFinal.ViewModels;
using BusinessTalkFinal.Helper;
using System.Collections.ObjectModel;
using BusinessTalkFinal.ViewModels.LoginVM;

namespace BusinessTalkFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        string _roomname;
        SignalrClient client = new SignalrClient();
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public bool Visible { get; set; }
        IList<SignalrUser> model = new ObservableCollection<SignalrUser>();
        ItemsViewModel viewModel;
        LoginViewModel loginViewModel;
      
        public ItemsPage()
        {
      
        }
        string _email;     
        public ItemsPage(string email)
        {
            InitializeComponent();
           
            _email = email;
            BindingContext = loginViewModel;
            BindingContext = viewModel = new ItemsViewModel();
        }          
        Item item;
        Users users = new Users();
        SignUpVM upVM = new SignUpVM();
        //LoginViewModel loginView = new LoginViewModel();
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
          
             item= args.SelectedItem as Item;
       
            await Navigation.PushAsync(new Chat(_email,item.Name));
          
            return;
         
        }     
        public string adminemail = "admin@gmail.com";
        async void AddItem_Clicked(object sender, EventArgs e)
        {  
            if (_email== adminemail)
            {
              
                await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
                    
            }
            else
            {
                DisplayAlert("Yetkilendirme Hatası", "Yönetici ile İletişime Geçiniz!", "OK");
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            var allPersons = await firebaseHelper.GetAllPersons();
            ItemsListView.ItemsSource = allPersons;
        }
        public async void Bind()
        {
            var allPersons = await firebaseHelper.GetAllPersons();
            ItemsListView.ItemsSource = allPersons;
        }             
    }
}