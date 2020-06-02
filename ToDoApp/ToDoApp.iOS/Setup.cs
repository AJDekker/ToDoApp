using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Foundation;
using ToDoApp.Repository;
using ToDoApp.Services;
using UIKit;

namespace ToDoApp.iOS
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