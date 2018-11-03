using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Services
{
    public class ViewFactory : IViewFactory
    {

        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;
        private readonly IAppConfig _appConfig;

        public ViewFactory(IComponentContext componentContext, IAppConfig appConfig)
        {
            _componentContext = componentContext;
            _appConfig = appConfig;
        }

        public void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public void Register(Type viewType, Type viewModelType)
        {
            _map[viewModelType] = viewType;
        }

        public Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var viewModel = _componentContext.Resolve<TViewModel>();


            Page view = GetView<TViewModel>();

            view.BindingContext = viewModel;
            return view;
        }

        public Page Resolve(Type viewModelType)
        {
            var viewModel = _componentContext.Resolve(viewModelType);


            Page view = GetView(viewModelType);

            view.BindingContext = viewModel;
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    private Page GetView<TViewModel>()
        {
            var type = typeof(TViewModel);

            return GetView(type);
        }

        private Page GetView(Type viewModel)
        {
            var type = viewModel;
            //si se registro el viewmodel y la página a mano, se busca en el diccionario
            if (_map.Keys.Contains(type))
            {
                var viewType = _map[type];
                return _componentContext.Resolve(viewType) as Page;
            }
            else
            {

                //                var strViewType = type.FullName?.Replace(".ViewModels.", ".Views.").Replace("ViewModel", string.Empty);

                var strViewType = _appConfig.ViewLocatorConvention(type.FullName);

                if (string.IsNullOrEmpty(strViewType)) throw new Exception($"Can't resolve view {strViewType} from {viewModel} viewModel");

                var asm = type.Assembly;
                var typePage = asm.GetType(strViewType);

                if (_componentContext.IsRegistered(typePage))
                {
                    return _componentContext.Resolve(typePage) as Page;
                }
                else
                {
                    try
                    {
                        return (Page)asm.CreateInstance(strViewType, true);
                    }
                    catch (Exception e)
                    {
                       if (System.Diagnostics.Debugger.IsAttached) Console.WriteLine(e);
                        throw;
                    }

                    
                }
            }
        }

    }
}
