using System;
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

namespace ToDoApp.Views.Sprint
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SprintListPage : ContentPage
    {
        SprintListViewModel viewModel;

        public SprintListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SprintListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ToDoApp.Models.Sprint;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new SprintDetailPage(new SprintDetailViewModel(item)));

            // Manually deselect item.
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