using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class TodoFirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://xflogin-384a3.firebaseio.com/");

        //Read All
        public static async Task<List<Todo>> GetAllTodo()
        {
            try
            {
                var todoList = (await firebase
                .Child("Todo")
                .OnceAsync<Todo>()).Select(item =>
                new Todo
                {
                    Name = item.Object.Name,
                    Description = item.Object.Description,
                    StoryPoints = item.Object.StoryPoints,
                    Due = item.Object.Due
                }).ToList();
                return todoList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read 
        public static async Task<Todo> GetTodo(Guid Id)
        {
            try
            {
                var allTodo = await GetAllTodo();
                await firebase
                .Child("Todo")
                .OnceAsync<Todo>();
                return allTodo.Where(a => a.Id == Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a todo
        public static async Task<bool> AddTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due)
        {
            try
            { 
                await firebase
                .Child("Todo")
                .PostAsync(new Todo() { Name = Name, Description = Description, StoryPoints = StoryPoints, Due = Due });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public static async Task<bool> UpdateTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due)
        {
            try
            {


                var toUpdateTodo = (await firebase
                .Child("Todo")
                .OnceAsync<Todo>()).Where(a => a.Object.Id == Id).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateTodo.Key)
                .PutAsync(new Todo() { Name = Name, Description = Description, StoryPoints = StoryPoints, Due = Due});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public static async Task<bool> DeleteTodo(Guid Id)
        {
            try
            {


                var toDeleteTodo = (await firebase
                .Child("Todo")
                .OnceAsync<Person>()).Where(a => a.Object.Id == Id).FirstOrDefault();
                await firebase.Child("Users").Child(toDeleteTodo.Key).DeleteAsync();
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
