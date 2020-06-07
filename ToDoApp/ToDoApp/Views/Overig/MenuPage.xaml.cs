using ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get =>  Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        { 

            try
            {
                InitializeComponent(); 
                menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Login, Title="Login" },
                new HomeMenuItem {Id = MenuItemType.Items, Title="Items list" }, 
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Todo, Title="Todo" },
                new HomeMenuItem {Id = MenuItemType.Sprint, Title="Sprint" }
            };

                ListViewMenu.ItemsSource = menuItems; 
                ListViewMenu.SelectedItem = menuItems[0];
                ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem == null)
                        return;

                    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                    await RootPage.NavigateFromMenu(id);
                };
            }
            catch
            {
                Console.WriteLine("fout");
            }
        }
    }
}