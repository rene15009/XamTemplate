using Autofac;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.Services;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Modules
{
	public class DependencyRegistrationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
			builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
			builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();
		}
	}
}
