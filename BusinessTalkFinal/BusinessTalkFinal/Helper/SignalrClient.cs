using BusinessTalkFinal.Models;
using BusinessTalkFinal.Views;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTalkFinal.Helper
{
  public class SignalrClient
    {
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        WelcomePage welcomePage = new WelcomePage();
        //EV
        //string url = "http://192.168.1.27/AAkademiSignalR2";
        string url= "http://businesstalk.eyomedia.com";
        HubConnection Connection;
        IHubProxy ChatHubProxy;
        public delegate void Error();
        public delegate void MessageReceived(SignalrUser user);
        public event Error ConnectionError;
        public event MessageReceived OnMessageReceived;
        public void Connect(string _username,string roomname)
        {
            Connection = new HubConnection(url, new Dictionary<string, string> {

                { "username", _username }
            }
            );
            Connection.StateChanged += Connection_StateChanged;
            ChatHubProxy = Connection.CreateHubProxy("ChatHub");
            ConnectedUser.Ids.Add(Connection.ConnectionId);           
            ChatHubProxy.On<string, string>("MessageReceived", (username, message) =>
            {
                var user = new SignalrUser
                {
                    username = username,
                    message = message,             
                };
                OnMessageReceived?.Invoke(user);
            });
            Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    ConnectionError.Invoke();
                }
            });
        }
    
        public void SendMessage(string username, string message, string groupname)
        {
            ChatHubProxy.Invoke("SendMessageToGroup", username, message, groupname);
        }
        public void SendMessagePrivate(string username, string message)
        {
            ChatHubProxy.Invoke("SendMessage", username, message);
        }
        private Task Start()
        {
            return Connection.Start();

        }
        private void Connection_StateChanged(StateChange obj)
        {
            // throw new NotImplementedException();
        }
      
        public void AddToRoom(string groupname)
        {
          
            ChatHubProxy.Invoke("AddGroups", groupname);
        }
      
        public void RemoveFromGroup(string groupname)
        {
            ChatHubProxy.Invoke("RemoveFromGroup", groupname);
        }
        public void trygroupchat()
        {
            ChatHubProxy.Invoke("denemegroupchat");
        }
    }
}


