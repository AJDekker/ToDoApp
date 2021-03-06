﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ToDoApp.Repository;
using ToDoApp.Services;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ILoginRepository _loginRepository;
        public readonly INavigationService _navigationService;
        public LoginViewModel(ILoginRepository loginRepository )
        {
            _loginRepository = loginRepository;
            _navigationService = App.NavigationService;
        }

        private Guid id;
        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushModalAsync(new SignUpPage()); });
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which C:\Users\arjan\source\repos\ToDoApp\ToDoApp\ToDoApp\ViewModels\LoginViewModel.cswe define in Firebase helper class
                var user = await _loginRepository.GetUser(Email);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page 
                        Application.Current.Properties["id"] = user.Id.ToString(); 

                        var navpage = new NavigationPage(new LoginPage());
                        await navpage.PushAsync(new AboutPage());
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
    }
} 