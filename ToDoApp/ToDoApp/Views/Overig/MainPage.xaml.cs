using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Views;

using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Views.Sprint;
using ToDoApp.Views.Todo;
using ToDoApp.ViewModels;
using ToDoApp.WeatherRestClient;

namespace ToDoApp.Views 
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            var api = new WeatherAPI();
            var pageService = new PageService();
            ViewModel = new WeatherPageViewModel(api, pageService);

            InitializeComponent();
        }


        public WeatherPageViewModel ViewModel
        {
            get { return BindingContext as WeatherPageViewModel; }
            set { BindingContext = value; }
        }


        void OnCitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectWeatherCommand.Execute(e.SelectedItem);
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        } 

    }
} 
