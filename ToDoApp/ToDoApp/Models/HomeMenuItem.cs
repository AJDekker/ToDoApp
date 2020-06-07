using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public enum MenuItemType
    {
        Login, 
        Items,
        Welcome,
        About,
        Todo,
        Sprint
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
