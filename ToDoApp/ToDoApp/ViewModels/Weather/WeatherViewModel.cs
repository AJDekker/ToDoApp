using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApp.Services;
using ToDoApp;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using ToDoApp.Views.Todo;
using Xamarin.Forms;

namespace ToDoApp.ViewModels.Weather
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        HttpClient _client;
        RestService _restService;

        public WeatherViewModel(string cityName = null)
        { 
            _client = new HttpClient();
            _restService = new RestService();
            city = cityName;
            if(city == null)
            {
                city = "Amsterdam";
            }
                    
            GetResultWeather();
        }
               

        public string city;

        public string City {
            get {
                return city;
            }
            set {
               city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("City"));
            } 
        }

        public double temperature;
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Temperature"));
            }
        }

        public double speed; 
        public double Speed { 
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Speed"));
            }
        }

        public double humidity;
        public double Humidity {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Humidity"));
            }
        }


        public Command OnGetWeatherButtonClicked
        { 
            get
            {
                return new Command(GetResultWeather);
            }
        }

        public async void GetResultWeather()
        {
            if (!string.IsNullOrWhiteSpace(city))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                Temperature = weatherData.Main.Temperature;
                Speed = weatherData.Wind.Speed;
                Humidity = weatherData.Main.Humidity;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={city}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
         }
        }
    }
