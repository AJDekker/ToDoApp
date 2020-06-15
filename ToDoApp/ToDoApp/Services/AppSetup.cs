using Autofac;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TodoApp.Repository.Sprint;
using TodoApp.Services;
using TodoApp.ViewModels;
using ToDoApp.Repository;
using ToDoApp.Repository.Sprint;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;
using ToDoApp.ViewModels.Weather;
using Xamarin.Forms;

namespace ToDoApp.Services
{
	public class AppSetup
	{
		public IContainer CreateContainer()
		{
			var containerBuilder = new ContainerBuilder();
			RegisterDependencies(containerBuilder);
			return containerBuilder.Build();
		}

		protected virtual void RegisterDependencies(ContainerBuilder cb)
		{
			// Register Services
			cb.RegisterType<LoginRepository>().As<ILoginRepository>(); 
			cb.RegisterType<TodoRepository>().As<ITodoRepository>();
			cb.RegisterType<SprintRepository>().As<ISprintRepository>();

			// Register View Models
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SprintViewModel>().SingleInstance();
			cb.RegisterType<TodoViewModel>().SingleInstance();
			cb.RegisterType<TodoListViewModel>().SingleInstance();
			cb.RegisterType<AboutViewModel>().SingleInstance(); 
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SignUpViewModel>().SingleInstance();
			cb.RegisterType<WelcomePageViewModel>().SingleInstance();
			cb.RegisterType<WeatherViewModel>().SingleInstance();
			cb.RegisterType<HttpClient>().SingleInstance();
			cb.RegisterType<RestService>().SingleInstance();
			cb.RegisterType<SprintListViewModel>().SingleInstance();
			cb.RegisterType<TodoDetailViewModel>().SingleInstance();
		}
	}
}