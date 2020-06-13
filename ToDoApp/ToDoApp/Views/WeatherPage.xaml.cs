using System;
using TodoApp.Services;
using ToDoApp.Models;
using ToDoApp.Services;
using Xamarin.Forms;

namespace ToDoApp.Views
{
    public partial class WeatherPage : ContentPage
    {
        RestService _restService;

        public WeatherPage()
        {
            InitializeComponent();

            _restService = new RestService();
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
