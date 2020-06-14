﻿using System;
using System.ComponentModel;
using Xamarin.Forms; 

using ToDoApp.Models;
using ToDoApp.ViewModels; 

namespace ToDoApp.Views.Todo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TodoDetailPage : ContentPage
    {
        TodoDetailViewModel viewModel;

        public TodoDetailPage(TodoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}