using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessTalkFinal.ViewModels.SignalrVM
{
   public class UserViewModel
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string CurrentRoom { get; set; }
        public string Device { get; set; }
    }
}
