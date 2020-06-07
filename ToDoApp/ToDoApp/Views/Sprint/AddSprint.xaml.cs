using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels.Sprint;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views.Sprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSprint : ContentPage
    {
        SprintViewModel todoViewModel;
        public AddSprint()
        {
            InitializeComponent();
            todoViewModel = Services.AppContainer.Container.Resolve<SprintViewModel>();
            BindingContext = todoViewModel;
        }
    }
}