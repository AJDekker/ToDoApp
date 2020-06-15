using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Views;

using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Views.Sprint;
using ToDoApp.Views.Todo;

namespace ToDoApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        private readonly INavigationService _navigationService;
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Welcome, (NavigationPage)Detail);

            _navigationService = App.NavigationService;

            NavigationPage.SetHasNavigationBar(this, false);
        } 
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {  
                    case (int)MenuItemType.Sprint:
                        MenuPages.Add(id, new NavigationPage(new SprintListPage()));
                        break;
                    case (int)MenuItemType.Todo:
                        MenuPages.Add(id, new NavigationPage(new TodoListPage()));
                        break;
                    case (int)MenuItemType.Weather:
                        MenuPages.Add(id, new NavigationPage(new WeatherPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}