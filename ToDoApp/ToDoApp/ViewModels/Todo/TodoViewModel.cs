using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using ToDoApp;
using ToDoApp.Models;
using ToDoApp.Repository;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using ToDoApp.Views.Todo;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        ITodoRepository _todoRepository;

        public Todo _todo;
         
        public TodoViewModel(ITodoRepository todoRepository, Guid Id, string name, string description, int storyPoints, DateTime due, Guid sprintId)
        {
            this.Id = Id;
            this.name = name;
            this.description = description;
            this.storyPoints = storyPoints;
            this.due = due;
            this.SprintId = sprintId;
            _todoRepository = todoRepository;
        }

        public TodoViewModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        private Guid id;

        public Guid Id
        {
            get { return id; }
            set
            {
                id = new Guid();
            }
        }
        

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
         
        private string description;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        private DateTime due;
        public DateTime Due
        {
            get
            {
                if (due.DayOfYear == 1)
                    return DateTime.Now;
                else
                {
                    return due;
                }
            }
            set
            {
                due = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Due"));
            }
        }

        private int storyPoints;
        public int StoryPoints
        {
            get { return storyPoints; }
            set
            {
                storyPoints = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Storypoints"));
            }
        }

        private Sprint sprint;

        public Sprint Sprint
        {
            get { return sprint; }
            set
            {
                sprint = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Sprint"));
            }
        }

        public Guid SprintId; 

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                { 
                        AddTodo(); 
                });
            }
        } 

        public async void AddTodo()
        { 

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description)) {
                //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            } else
            { 
                    var todo = await _todoRepository.AddTodo(Id, name, description, storyPoints, due, SprintId);
                   

                    if (todo != null)
                    {
                    //await App.Current.MainPage.DisplayAlert("Save todo Success", "", "Ok"); 

                    //await App.Current.MainPage.Navigation.PushModalAsync(new TodoListPage());
                   
                    }
                    
            }
        }

        public async void UpdateTodo()
        {


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            }
            else
            {

                var todo = await _todoRepository.UpdateTodo(Id, name, description, storyPoints, due);


                if (todo != null)
                {
                    //await App.Current.MainPage.DisplayAlert("Save todo Success", "", "Ok");


                    //await App.Current.MainPage.Navigation.PushModalAsync(new TodoListPage());

                }

            }
        }

        public async void Delete()
        {


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            }
            else
            {

                var todo = await _todoRepository.DeleteTodo(Id);

                //AddUser return true if data insert successfuly 
                if (todo != null)
                {
                    //await App.Current.MainPage.DisplayAlert("Save todo Success", "", "Ok");

                    //await App.Current.MainPage.Navigation.PushModalAsync(new TodoListPage());

                }

            }
        }
    }
}
            