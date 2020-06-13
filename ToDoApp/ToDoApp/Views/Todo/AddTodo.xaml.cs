using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModels;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTodo : ContentPage
    {
        TodoViewModel todoViewModel;
        public AddTodo()
        {
            InitializeComponent();
            todoViewModel = Services.AppContainer.Container.Resolve<TodoViewModel>(); 
            todoViewModel.sprintId = new Guid(Application.Current.Properties["SprintId"].ToString());
            BindingContext = todoViewModel;
        }
    }
}