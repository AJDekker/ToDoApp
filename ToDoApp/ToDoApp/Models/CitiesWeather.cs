using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class CitiesWeather
    {
        [JsonProperty("list")]
        public List<Weather> Weather { get; set; }
    }
}