﻿using BusinessTalkFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessTalkFinal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserList : ContentPage
	{
      
		public UserList ()
		{
			InitializeComponent ();
        
    }
        public static List<string> Ids = new List<string>();
    }
}