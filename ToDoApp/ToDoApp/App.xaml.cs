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
            Application.Current.Properties["id"] = "";

            NavigationService.Configure("MainPage", typeof(Views.MainPage));
            NavigationService.Configure("AboutPage", typeof(Views.AboutPage));  
            NavigationService.Configure("LoginPage", typeof(Views.LoginPage));
            NavigationService.Configure("MenuPage", typeof(Views.MenuPage)); 
            NavigationService.Configure("SignUpPage", typeof(Views.SignUpPage)); 
            NavigationService.Configure("WelcomePage", typeof(Views.WelcomePage));  
            var mainPage = ((NavigationService)NavigationService).SetRootPage("MainPage");
            MainPage = new ToDoApp.Views.MainPage();
        }

        public static INavigationService NavigationService { get; } = new NavigationService();


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
