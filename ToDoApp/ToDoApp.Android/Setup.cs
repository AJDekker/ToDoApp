using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using TodoApp.Repository.Sprint;
using TodoApp.Services;
using TodoApp.ViewModels;
using ToDoApp.Repository;
using ToDoApp.Repository.Sprint;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;
using ToDoApp.ViewModels.Weather;

namespace ToDoApp.Droid
{
	public class Setup : AppSetup
	{
		protected override void RegisterDependencies(ContainerBuilder cb)
		{
			base.RegisterDependencies(cb);

			cb.RegisterType<LoginRepository>().As<ILoginRepository>();
			cb.RegisterType<TodoRepository>().As<ITodoRepository>();

			cb.RegisterType<SprintRepository>().As<ISprintRepository>();

			// Register View Models
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SprintListViewModel>().SingleInstance();
			cb.RegisterType<SprintViewModel>().SingleInstance();
			cb.RegisterType<TodoViewModel>().SingleInstance();
			cb.RegisterType<TodoDetailViewModel>().SingleInstance();
			cb.RegisterType<AboutViewModel>().SingleInstance(); 
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SignUpViewModel>().SingleInstance();
			cb.RegisterType<WelcomePageViewModel>().SingleInstance();
			cb.RegisterType<WeatherViewModel>().SingleInstance(); 
			cb.RegisterType<RestService>().SingleInstance();
		}
	}
}