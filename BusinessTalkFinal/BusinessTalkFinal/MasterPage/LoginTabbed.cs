using BusinessTalkFinal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.MasterPage
{
    public class LoginTabbed : TabbedPage
    {
        public LoginTabbed()
        {
            Children.Add(new LoginPage());
            Children.Add(new SignUpPage());
        }
    }
}
