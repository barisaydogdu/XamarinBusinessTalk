using BusinessTalkFinal.Models;
using Firebase.Database;
using Firebase.Database.Query;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTalkFinal.Helper
{
    public class FirebaseHelper
    {
        readonly List<Item> items;
        public static FirebaseClient firebase = new FirebaseClient("https://businesstalk-6920a.firebaseio.com/");
        public async Task<List<Item>> GetAllPersons()
        {
            return (await firebase
             .Child("Persons")
             .OnceAsync<Item>()).Select(item => new Item
             {
                 Name = item.Object.Name,
                 PersonId = item.Object.PersonId
             }).ToList();
         
        }
         
        public async Task AddPerson(int personıd, string name/*,string deneme*/,string datetime)
        {
            await firebase
           .Child("Persons")
           .PostAsync(new Item() { PersonId = personıd, Name = name /*Id = deneme*/,dateTime=datetime});
        }
        public async Task<Item> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase       
              .Child("Persons")
              .OnceAsync<Item>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }
        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Item>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Item() { PersonId = personId, Name = name });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Item>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }

        Item item;
        SignalrUser _signalr;
     
        public async Task<List<SignalrUser>> GetAllMessage(string groupname)
        {
            return (await firebase
             .Child("Messages "+groupname)
             .OnceAsync<SignalrUser>()).Select(item => new SignalrUser
             {
                 username = item.Object.username,
                 message = item.Object.message,

             }).ToList();
        }
        public async Task AddMessage(string userName, string _message, string _groupname)
        {
            await firebase
           .Child("Messages "+_groupname)
           .PostAsync(new SignalrUser() { username = userName, message = _message, groupname = _groupname });
        }
        public async Task<SignalrUser> GetMessage(string personId)
        {

            var allPersons = await GetAllMessage(item.Name);
            await firebase

              //  .Child("Persons")
              .Child("Messages"+personId)
              .OrderByKey()     
           .OnceAsync<SignalrUser>();

            foreach (var item in allPersons)
            {
                Console.WriteLine($"{item.groupname}");
            }
            return allPersons.Where(a => a.username == personId).FirstOrDefault();

        }
        //Login Auth 
        public static async Task<List<Users>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<Users> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<bool> AddUser(string email, string password)
        {
            try
            {
                await firebase
                .Child("Users")
                .PostAsync(new Users() { Email = email, Password = password});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {
                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public static async Task<bool> DeleteUser(string email,string password)
        {
            try
            {
                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public async Task<List<LocalHostModel>> GetAllLocalHost( )
        {
            return (await firebase
             .Child("LocalHost")
            // .Child("Messages")
             .OnceAsync<LocalHostModel>()).Select(item => new LocalHostModel
             {    Local=item.Object.Local,
             }).ToList();

        }
        public async Task AddLocalHost(string localid)
        {     
            await firebase
           .Child("LocalHost")
           .PostAsync(new LocalHostModel() { Local = localid});
        }
        public async Task<LocalHostModel> GetLocalHost(string localid)
        {
            var allPersons = await GetAllLocalHost();
            await firebase      
              .Child("LocalHost")
              .OnceAsync<LocalHostModel>();
            return allPersons.Where(a => a.Local== localid).FirstOrDefault();
        }

    }
}


