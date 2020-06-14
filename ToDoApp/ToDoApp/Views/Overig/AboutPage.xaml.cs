using Autofac;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewmodel;
        public AboutPage()
        {
            InitializeComponent();
            viewmodel = Services.AppContainer.Container.Resolve<AboutViewModel>();
            BindingContext = viewmodel; 
        }
    }
}