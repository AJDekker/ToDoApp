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
using ToDoApp.Repository;
using ToDoApp.Services;

namespace ToDoApp.Droid
{
	public class Setup : AppSetup
	{
		protected override void RegisterDependencies(ContainerBuilder cb)
		{
			base.RegisterDependencies(cb);

			cb.RegisterType<LoginRepository>().As<ILoginRepository>();
		}
	}
}