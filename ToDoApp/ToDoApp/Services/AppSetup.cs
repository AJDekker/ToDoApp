using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Repository;
using ToDoApp.ViewModels;

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
			cb.RegisterType<AboutViewModel>().SingleInstance();
			cb.RegisterType<ItemDetailViewModel>().SingleInstance();
			cb.RegisterType<ItemsViewModel>().SingleInstance();
			cb.RegisterType<LoginViewModel>().SingleInstance();
			cb.RegisterType<SignUpViewModel>().SingleInstance();
			cb.RegisterType<WelcomePageViewModel>().SingleInstance();
		}
	}
}