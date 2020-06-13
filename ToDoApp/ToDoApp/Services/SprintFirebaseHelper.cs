using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class SprintFirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://xflogin-384a3.firebaseio.com/");

        //Read All
        public static async Task<List<ToDoApp.Models.Sprint>> GetAllSprint()
        {
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString());

            try
            {
                var SprintList = (await firebase
                .Child("Sprint")
                .OnceAsync<ToDoApp.Models.Sprint>()).Where(item => item.Object.PersonId == PersonId).Select(item =>
                new ToDoApp.Models.Sprint
                {
                    Id = item.Object.Id,
                    Name = item.Object.Name, 
                    StoryPoints = item.Object.StoryPoints, 
                }).ToList();
                return SprintList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        } 

        //Read 
        public static async Task<ToDoApp.Models.Sprint> GetSprint(Guid Id)
        {
            try
            {
                var allSprint = await GetAllSprint();
                await firebase
                .Child("Sprint")
                .OnceAsync<ToDoApp.Models.Sprint>();
                return allSprint.Where(a => a.Id == Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a Sprint
        public static async Task<bool> AddSprint(Guid Id, string Name, int StoryPoints)
        {
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString()); 
            try
            { 
                await firebase
                .Child("Sprint")
                .PostAsync(new ToDoApp.Models.Sprint() {Id = Id, Name = Name, StoryPoints = StoryPoints, PersonId = PersonId });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public static async Task<bool> UpdateSprint(Guid Id, string Name, int StoryPoints )
        {
            try
            {


                var toUpdateSprint = (await firebase
                .Child("Sprint")
                .OnceAsync<ToDoApp.Models.Sprint>()).Where(a => a.Object.Id == Id).FirstOrDefault();
                await firebase
                .Child("Sprint")
                .Child(toUpdateSprint.Key)
                .PutAsync(new ToDoApp.Models.Sprint() { Name = Name, StoryPoints = StoryPoints });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public static async Task<bool> DeleteSprint(Guid Id)
        {
            try
            {


                var toDeleteSprint = (await firebase
                .Child("Sprint")
                .OnceAsync<Person>()).Where(a => a.Object.Id == Id).FirstOrDefault();
                await firebase.Child("Sprint").Child(toDeleteSprint.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}
