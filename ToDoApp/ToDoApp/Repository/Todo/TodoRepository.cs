using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Repository
{
    public class TodoRepository : ITodoRepository
    {

        public async Task<List<Todo>> GetAllTodo()
        {
            return await TodoFirebaseHelper.GetAllTodo();
        }

        //Read 
        public async Task<Todo> GetTodo(Guid Id)
        {
            return await TodoFirebaseHelper.GetTodo(Id);
        }

        //Inser a user
        public async Task<bool> AddTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due)
        {
            return await TodoFirebaseHelper.AddTodo(Id, Name, Description, StoryPoints, Due);
        }

        //Update 
        public async Task<bool> UpdateTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due)
        {
            return await TodoFirebaseHelper.UpdateTodo(Id, Name, Description, StoryPoints, Due);
        }

        //Delete User
        public async Task<bool> DeleteTodo(Guid Id)
        {
            return await TodoFirebaseHelper.DeleteTodo(Id);
        }

    }
}
