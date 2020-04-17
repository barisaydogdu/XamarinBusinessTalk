using BusinessTalkFinal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.MasterPage
{
   public class MyMasterPage:MasterDetailPage
    {
        public MyMasterPage()
        {
            Title = "BusinessTalk";
            Master = new MenuPage();
            Detail = new NavigationPage(new NewItemPage());
        }
    }
}
