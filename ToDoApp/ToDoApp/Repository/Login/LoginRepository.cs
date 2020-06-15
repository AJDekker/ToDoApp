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
            return await UserFirebaseHelper.GetAllUser();
        }

        // Read 
        public async Task<Person> GetUser(string email)
        {
            return await UserFirebaseHelper.GetUser(email);
        }

        // Inser a user
        public async Task<bool> AddUser(string email, string password)
        {
            return await UserFirebaseHelper.AddUser(email, password);
        }

        // Update 
        public async Task<bool> UpdateUser(Guid Id, string email, string password)
        {
            return await UserFirebaseHelper.UpdateUser(Id, email, password);
        }

        // Delete User
        public async Task<bool> DeleteUser(Guid Id)
        {
            return await UserFirebaseHelper.DeleteUser(Id);
        }

    }
}
