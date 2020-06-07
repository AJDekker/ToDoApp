

using System.ComponentModel;
using ToDoApp.ViewModels.Sprint;
using Xamarin.Forms;

namespace ToDoApp.Views.Sprint
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SprintDetailPage : ContentPage
    {
        SprintDetailViewModel viewModel;

        public SprintDetailPage(SprintDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public SprintDetailPage()
        {
            InitializeComponent();

            var item = new ToDoApp.Models.Sprint
            {
                Name = "Item 1",
                StoryPoints = 1
            };

            viewModel = new SprintDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}