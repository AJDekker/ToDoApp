using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Services;
using ToDoApp.Views;

namespace ToDoApp
{
    public partial class App : Application
    {

        public App(AppSetup setup)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            AppContainer.Container = setup.CreateContainer();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
