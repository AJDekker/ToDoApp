using System;

using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class TodoDetailViewModel : BaseViewModel
    {
        public Todo Item { get; set; }
        public TodoDetailViewModel(Todo item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
