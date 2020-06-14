using System;
using System.ComponentModel;
using System.Net.Http;
using TodoApp.Services;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels.Weather;

namespace ToDoApp.ViewModels
{
    public class TodoDetailViewModel : BaseViewModel
    { 
        public Todo Item { get; set; }

        public TodoDetailViewModel(Todo item = null, WeatherViewModel weatherViewModel = null)
        {
            Title = item?.Name;
            Item = item; 
        }

        public string City; 

        public double Temperature; 

        public double Speed; 

        public double Humidity; 

         
    }
}

