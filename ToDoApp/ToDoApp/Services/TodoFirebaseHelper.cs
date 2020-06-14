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
    public class TodoFirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://xflogin-384a3.firebaseio.com/");

        //Read All
        public static async Task<List<Todo>> GetAllTodo()
        {
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString());
            try
            {
                var todoList = (await firebase
                .Child("Todo")
                .OnceAsync<Todo>()).Where(item => item.Object.PersonId == PersonId).Select(item =>
                new Todo
                {
                    Name = item.Object.Name,
                    Description = item.Object.Description,
                    StoryPoints = item.Object.StoryPoints,
                    Due = item.Object.Due,
                    City = item.Object.City
                }).ToList(); 
                return todoList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<List<Todo>> GetAllTodoBySprint()
        {
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString()); 
            Guid SprintId = new Guid(Application.Current.Properties["SprintId"].ToString());

            try
            {
                var todoList = (await firebase
                .Child("Todo")
                .OnceAsync<Todo>()).Where(item => item.Object.SprintId == SprintId && item.Object.PersonId == PersonId).Select(item =>
                new Todo
                {
                    Name = item.Object.Name,
                    Description = item.Object.Description,
                    StoryPoints = item.Object.StoryPoints,
                    Due = item.Object.Due,
                    City = item.Object.City
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
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString());

            try
            {
                var allTodo = await GetAllTodo();
                await firebase
                .Child("Todo")
                .OnceAsync<Todo>();
                return allTodo.Where(a => a.Id == Id && a.PersonId == PersonId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a todo
        public static async Task<bool> AddTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due, Guid SprintId, string city)
        {
            Guid PersonId = new Guid(Application.Current.Properties["id"].ToString());
            try
            { 
                await firebase
                .Child("Todo")
                .PostAsync(new Todo() { Name = Name, Description = Description, StoryPoints = StoryPoints, Due = Due, SprintId = SprintId, PersonId = PersonId, City = city });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public static async Task<bool> UpdateTodo(Guid Id, string Name, string Description, int StoryPoints, DateTime Due, string city)
        {
            try
            {


                var toUpdateTodo = (await firebase
                .Child("Todo")
                .OnceAsync<Todo>()).Where(a => a.Object.Id == Id).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateTodo.Key)
                .PutAsync(new Todo() { Name = Name, Description = Description, StoryPoints = StoryPoints, Due = Due, City = city});
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
