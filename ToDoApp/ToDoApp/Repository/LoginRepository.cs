using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Repository
{
    public class LoginRepository : ILoginRepository
    {

        public async Task<List<Person>> GetAllUser()
        {
            return await FirebaseHelper.GetAllUser();
        }

        //Read 
        public async Task<Person> GetUser(string email)
        {
            return await FirebaseHelper.GetUser(email);
        }

        //Inser a user
        public async Task<bool> AddUser(string email, string password)
        {
            return await FirebaseHelper.AddUser(email, password);
        }

        //Update 
        public async Task<bool> UpdateUser(string email, string password)
        {
            return await FirebaseHelper.UpdateUser(email, password);
        }

        //Delete User
        public async Task<bool> DeleteUser(string email)
        {
            return await FirebaseHelper.DeleteUser(email);
        }

    }
}
