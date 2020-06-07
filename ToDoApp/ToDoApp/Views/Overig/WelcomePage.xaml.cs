using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        WelcomePageViewModel welcomePageViewModel;
        public WelcomePage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent(); 
            welcomePageViewModel = AppContainer.Container.Resolve<WelcomePageViewModel>();
            BindingContext = welcomePageViewModel;
        } 
    }
}