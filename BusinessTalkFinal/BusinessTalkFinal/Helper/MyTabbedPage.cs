using BusinessTalkFinal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.Helper
{
    public class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage(string email)
        {
            Children.Add(new ItemsPage(email));
            Children.Add(new WelcomePage(email));      
        }
      
    }
}
