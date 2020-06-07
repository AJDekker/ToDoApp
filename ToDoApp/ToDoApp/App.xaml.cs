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
            Application.Current.Properties["email"] = "";

            NavigationService.Configure("MainPage", typeof(Views.MainPage));
            NavigationService.Configure("AboutPage", typeof(Views.AboutPage)); 
            NavigationService.Configure("ItemDetailPage", typeof(Views.ItemDetailPage));
            NavigationService.Configure("ItemsPage", typeof(Views.ItemsPage));
            NavigationService.Configure("LoginPage", typeof(Views.LoginPage));
            NavigationService.Configure("MenuPage", typeof(Views.MenuPage));
            NavigationService.Configure("NewItemPage", typeof(Views.NewItemPage));
            NavigationService.Configure("SignUpPage", typeof(Views.SignUpPage)); 
            NavigationService.Configure("WelcomePage", typeof(Views.WelcomePage));  
            var mainPage = ((NavigationService)NavigationService).SetRootPage("MainPage");
            MainPage = new MainPage();
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
