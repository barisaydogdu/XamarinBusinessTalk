using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace AAkademiSignalR2
{
    public class ChatHub : Hub
    {
        public void SendMessage(string username, string message)
        {
            Clients.All.MessageReceived(username, message);
        }
      
        public override Task OnConnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"]," Bağlandı!");
            ConnectedUser.Ids.Add(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.MessageReceived(Context.QueryString["username"]
                , " Bağlantı Koptu!");
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"], " Yeniden Bağlandı!");
            return base.OnReconnected();
        }

        public  void SendMessageToGroup(string username,string message,string groupname)
        {
            Clients.Group(groupname).MessageReceived(username, message);
        }
        public Task AddGroups(string groupname)
        {  
            return Groups.Add(Context.ConnectionId,groupname);
        }
        public void denemegroupchat(string groupname,string username,string message)
        {
            Clients.Group(groupname, Context.ConnectionId, Context.ConnectionId).addChatMessage(username, message);
        }
        public void AddList(string room)
        {
            // Create a list  
            List<string> AuthorList = new List<string>();
            // Add items using Add method   
            AuthorList.Add(room);
        }
        public async Task RemoveFromGroup(string username, string groupName)
        {
            await Clients.Group(groupName).SendAsync("Send", $"{username} is leaving the group {groupName}.");
            await Groups.Remove(Context.ConnectionId,"Baris" );
        }
    }
}