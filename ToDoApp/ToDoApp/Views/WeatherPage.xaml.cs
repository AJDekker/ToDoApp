using Autofac;
using System;
using TodoApp.Services;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels.Weather;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        WeatherViewModel weatherViewModel;

        public WeatherPage()
        {
            InitializeComponent();
            weatherViewModel = AppContainer.Container.Resolve<WeatherViewModel>();
            BindingContext = weatherViewModel;
        } 
    }
}
