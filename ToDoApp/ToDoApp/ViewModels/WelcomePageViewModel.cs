﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class WelcomePageViewModel : INotifyPropertyChanged
    {
        public WelcomePageViewModel()
        {
            Email = Application.Current.Properties["email"].ToString();
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }

        public Command DeleteCommand
        {
            get { return new Command(Delete); }
        }
        //For Logout
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                });
            }
        }
        //Update user data
        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FirebaseHelper.UpdateUser(Email, Password);
                    if (isupdate)
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                    else
                        await App.Current.MainPage.DisplayAlert("Error", "Record not update", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
        //Delete user data
        private async void Delete()
        {
            try
            {
                var isdelete = await FirebaseHelper.DeleteUser(Email);
                if (isdelete)
                    await App.Current.MainPage.Navigation.PopAsync();
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Record not delete", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
    }
}
