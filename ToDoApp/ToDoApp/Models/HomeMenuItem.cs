using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public enum MenuItemType
    {
        TodoList,
        Sprint,
        Epic
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
