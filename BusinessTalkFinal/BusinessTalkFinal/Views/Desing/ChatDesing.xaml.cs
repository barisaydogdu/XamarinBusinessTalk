using BusinessTalkFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessTalkFinal.Views.Desing
{  
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatDesing : ContentPage
	{
        ChatqViewModel vm;
        public ChatDesing ()
		{
			InitializeComponent ();
            BindingContext = vm = new ChatqViewModel();


            vm.ListMessages.CollectionChanged += (sender, e) =>
            {
                var target = vm.ListMessages[vm.ListMessages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            };
        }

        private void Sendqbtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
