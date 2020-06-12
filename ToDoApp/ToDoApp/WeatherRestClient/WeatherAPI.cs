using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.WeatherRestClient
{
    public class  WeatherAPI : IWeatherRepository
    {
        private const string OpenWeatherApi = "https://api.openweathermap.org/data/2.5/weather?q=";
        private const string OpenMultipleWeatherApi = "https://api.openweathermap.org/data/2.5/box/city?bbox=";
        private const string Key = "653b1f0bf8a08686ac505ef6f05b94c2";
        HttpClient _httpClient = new HttpClient();

        public async Task<CitiesWeather> GetSeveralCitiesWheaterAsync()
        {

            var json = await _httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/box/city?bbox=12,32,15,37,10" + "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<CitiesWeather>(json);
            return getWeatherModels;
        }

        public async Task<Weather> GetWheater(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<Weather>(json);
            return getWeatherModels;
        }
    }
}