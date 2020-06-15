using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;


namespace TodoApp.Repository.Sprint
{
    public interface ISprintRepository
    {
        Task<List<ToDoApp.Models.Sprint>> GetAllSprint();

        // Read 
        Task<ToDoApp.Models.Sprint> GetSprint(Guid Id);

        //Inser a Sprint
        Task<bool> AddSprint(Guid Id, string Name, int StoryPoints);

        //Update Sprint
        Task<bool> UpdateSprint(Guid Id, string Name, int StoryPoints);

        //Delete Sprint
        Task<bool> DeleteSprint(Guid Id);

    }
}
