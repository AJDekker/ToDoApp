using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Repository.Sprint;
using ToDoApp.ViewModels;

namespace ToDoApp.Repository.Sprint
{
    public class SprintRepository : ISprintRepository
    {

        public async Task<List<ToDoApp.Models.Sprint>> GetAllSprint()
        {
            return await SprintFirebaseHelper.GetAllSprint();
        }

        //Read 
        public async Task<ToDoApp.Models.Sprint> GetSprint(Guid Id)
        {
            return await SprintFirebaseHelper.GetSprint(Id);
        }

        //Inser a user
        public async Task<bool> AddSprint(Guid Id, string Name,  int StoryPoints )
        {
            return await SprintFirebaseHelper.AddSprint(Id, Name, StoryPoints );
        }

        //Update 
        public async Task<bool> UpdateSprint(Guid Id, string Name, int StoryPoints )
        {
            return await SprintFirebaseHelper.UpdateSprint(Id, Name , StoryPoints);
        }

        //Delete User
        public async Task<bool> DeleteSprint(Guid Id)
        {
            return await SprintFirebaseHelper.DeleteSprint(Id);
        }

    }
}
