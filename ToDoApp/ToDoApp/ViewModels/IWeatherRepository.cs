using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public interface IWeatherRepository
    {
        Task<CitiesWeather> GetSeveralCitiesWheaterAsync();
        Task<Weather> GetWheater(string city);
    }
}