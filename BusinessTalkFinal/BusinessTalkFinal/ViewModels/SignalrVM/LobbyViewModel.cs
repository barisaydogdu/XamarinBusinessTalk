using BusinessTalkFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BusinessTalkFinal.ViewModels.SignalrVM
{
  public class LobbyViewModel
    { 

        public LobbyViewModel()
        {
            //Rooms = GetRooms();
        }
        ObservableCollection<Rooms> _rooms = new ObservableCollection<Rooms>();
        public async Task GoToGroupChat(INavigation navigation)
        {

      
        }

    }
}





