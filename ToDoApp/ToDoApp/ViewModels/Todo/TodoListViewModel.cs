using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp.ViewModels
{
    public class TodoListViewModel : BaseViewModel
    {
        public ObservableCollection<Todo> Items { get; set; }
        public Command LoadItemsCommand { get; set; } 

        public TodoListViewModel()
        { 
            Title = "Browse";
            Items = new ObservableCollection<Todo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ToDoApp.Views.AddTodo, Todo>(this, "AddTodo", async (obj, item) =>
            {
                var newTodo = item as Todo;
                Items.Add(newTodo); 
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true; 
            try
            {
                Items.Clear();
                var items = await TodoFirebaseHelper.GetAllTodoBySprint();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}