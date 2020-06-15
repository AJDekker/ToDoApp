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

namespace ToDoApp.Views.Todo
{

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

            await Navigation.PushModalAsync(new TodoDetailPage(new TodoDetailViewModel(item)));


            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushModalAsync(new NavigationPage(new AddTodo()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}