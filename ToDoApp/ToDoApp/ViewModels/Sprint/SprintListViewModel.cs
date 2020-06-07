using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms; 
using ToDoApp.Views.Sprint;

namespace ToDoApp.ViewModels.Sprint
{
    public class SprintListViewModel : BaseViewModel
    {
        public ObservableCollection<ToDoApp.Models.Sprint> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SprintListViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ToDoApp.Models.Sprint>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddSprint, ToDoApp.Models.Sprint>(this, "AddSprint", async (obj, item) =>
            {
                var newSprint = item as ToDoApp.Models.Sprint;
                Items.Add(newSprint); 
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
                var items = await SprintFirebaseHelper.GetAllSprint();
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