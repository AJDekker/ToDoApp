using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDetailPage : ContentPage
    {

        public WeatherDetailPage()
        {
            InitializeComponent();
            BindingContext = new WeatherDetailPageViewModel();
        }

        public WeatherDetailPage(WeatherDetailPageViewModel viewModel)
        {
            //ViewModel = viewModel;
            InitializeComponent();

        }

    }
}