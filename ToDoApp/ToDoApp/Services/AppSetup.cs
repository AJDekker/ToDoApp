using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.ViewModels;
using ToDoApp.Repository;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;
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

			// Register View Models
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SprintViewModel>().SingleInstance();
			cb.RegisterType<TodoViewModel>().SingleInstance(); 
			cb.RegisterType<AboutViewModel>().SingleInstance();
			cb.RegisterType<ItemDetailViewModel>().SingleInstance(); 
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SignUpViewModel>().SingleInstance();
			cb.RegisterType<WelcomePageViewModel>().SingleInstance();
		}
	}
}