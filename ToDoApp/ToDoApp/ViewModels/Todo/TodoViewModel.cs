using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoApp;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using ToDoApp.Views.Todo;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
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

        public Guid sprintId; 

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                { 
                        SignUp(); 
                });
            }
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class
                var todo = await TodoFirebaseHelper.AddTodo(Id, Name, Description,  StoryPoints, Due, sprintId);
                //AddUser return true if data insert successfuly 
                if (todo)
                {
                    await App.Current.MainPage.DisplayAlert("Save todo Success", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp
                    //pass user email to welcom page
                    await App.Current.MainPage.Navigation.PushModalAsync(new TodoListPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Save todo Fail", "OK");
            }
        }
    }
}
            