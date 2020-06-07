using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTodo();

        //Read 
        Task<Todo> GetTodo(Guid Id);

        //Inser a todo
        Task<bool> AddTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due);

        //Update todo
        Task<bool> UpdateTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due);

        //Delete todo
        Task<bool> DeleteTodo(Guid Id);

    }
}
