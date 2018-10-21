using System.Linq;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.ViewModels;
using Xam.Template.ViewModels.Controls;
using Module = Autofac.Module;

namespace Rene.Xam.Extensions.Bootstrapping.Modules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();
            builder
                .RegisterAssemblyTypes(asm)
                .Where(t => t.GetInterfaces().Contains(typeof(IInyectableViewModel)))
                .AsImplementedInterfaces();


            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<PruebaViewModel>();


        }
    }
}
