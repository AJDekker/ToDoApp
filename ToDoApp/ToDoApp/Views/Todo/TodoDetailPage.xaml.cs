using System;
using System.ComponentModel;
using Xamarin.Forms; 

using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Weather;
using System.Net.Http;
using TodoApp.Services;
using ToDoApp.Services;

namespace ToDoApp.Views.Todo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TodoDetailPage : ContentPage
    {
        TodoDetailViewModel viewModel; 
        HttpClient _client;
        RestService _restService;
        TodoDetailViewModel todoDetailViewModel;
        string City;
        public TodoDetailPage(ToDoApp.Models.Todo item)
        {
            InitializeComponent();
            City = item.City;
            _restService = new RestService();
            todoDetailViewModel = new TodoDetailViewModel();
            start(todoDetailViewModel);
        }

        public TodoDetailPage()
        {
            InitializeComponent();

            var item = new ToDoApp.Models.Todo
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new TodoDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void start(TodoDetailViewModel todoDetailViewModel)
        {
            WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint)); 
            todoDetailViewModel.Temperature = weatherData.Main.Temperature;
            todoDetailViewModel.Humidity = weatherData.Main.Humidity;
            todoDetailViewModel.Speed = weatherData.Wind.Speed;
            BindingContext = this.viewModel = todoDetailViewModel;
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={City}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
