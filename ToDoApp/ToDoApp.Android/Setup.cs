using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using TodoApp.ViewModels;
using ToDoApp.Repository;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;

namespace ToDoApp.Droid
{
	public class Setup : AppSetup
	{
		protected override void RegisterDependencies(ContainerBuilder cb)
		{
			base.RegisterDependencies(cb);

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