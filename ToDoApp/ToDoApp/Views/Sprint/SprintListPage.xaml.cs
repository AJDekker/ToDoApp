﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoApp.Models;
using ToDoApp.Views;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint; 
using ToDoApp.Views.Sprint;
using ToDoApp.Views.Todo;
using Autofac;

namespace ToDoApp.Views.Sprint
{

    [DesignTimeVisible(false)]
    public partial class SprintListPage : ContentPage
    {
        SprintListViewModel viewModel;

        public SprintListPage()
        {
            InitializeComponent();
            viewModel = Services.AppContainer.Container.Resolve<SprintListViewModel>();
            BindingContext = viewModel;
        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ToDoApp.Models.Sprint;
            if (item == null)
                return; 
            Application.Current.Properties["SprintId"] = item.Id.ToString();
            await Navigation.PushAsync(new NavigationPage(new TodoListPage()));


        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddSprint()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}