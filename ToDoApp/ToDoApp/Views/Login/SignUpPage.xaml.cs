using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpViewModel signUpViewModel;
        public SignUpPage()
        {
            InitializeComponent();
            signUpViewModel = Services.AppContainer.Container.Resolve<SignUpViewModel>(); 
            BindingContext = signUpViewModel;
        }
    }
}