using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddTodoAsync(T todo);
        Task<bool> UpdateTodoAsync(T todo);
        Task<bool> DeleteTodoAsync(Guid id);
        Task<T> GetTodoAsync(Guid id);
        Task<List<T>> GetTodosAsync(bool forceRefresh = false);
    }
}
