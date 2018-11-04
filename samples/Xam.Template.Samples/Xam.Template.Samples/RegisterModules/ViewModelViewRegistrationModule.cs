using System.Linq;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.Samples.ViewModels;
using Xam.Template.Samples.ViewModels.Controls;
using Module = Autofac.Module;

namespace Xam.Template.Samples.RegisterModules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();   
            //TODO: Fix assembly scan. It doesn't work.
            builder
                .RegisterAssemblyTypes(asm)
                .Where(t => t.GetInterfaces().Contains(typeof(IInyectableViewModel)))
                .AsImplementedInterfaces();

         

            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<AboutViewModel>();
            builder.RegisterType<ItemsViewModel>();
            builder.RegisterType<ItemDetailViewModel>();
            builder.RegisterType<NewItemViewModel>();


        }
    }
}
