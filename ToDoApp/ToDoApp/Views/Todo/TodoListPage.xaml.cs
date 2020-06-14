using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoApp.Models;
using ToDoApp.Views;
using ToDoApp.ViewModels;
using Autofac.Core;
using Autofac;
using ToDoApp.ViewModels.Weather;

namespace ToDoApp.Views.Todo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TodoListPage : ContentPage
    {
        TodoListViewModel viewModel; 

        public TodoListPage()
        {
            InitializeComponent();
            viewModel = Services.AppContainer.Container.Resolve<TodoListViewModel>(); 
            BindingContext = viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ToDoApp.Models.Todo;
            if (item == null)
                return; 
            await Navigation.PushModalAsync(new TodoDetailPage(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushModalAsync(new NavigationPage(new AddTodo()));
            Console.WriteLine("tesaaaat");
            Console.WriteLine(Id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}