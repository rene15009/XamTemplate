using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.Modules;
using Rene.Xam.Extensions.Bootstrapping.Services;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping
{
    public static class BoostrapperExtensions
    {
        public static IBootstrapper Setup(this Application app)
        {
            return new Bootstrapper(app);
        }



    }

    internal class Bootstrapper : IRegisterView, IBootstrapper, IConfigurationOptions

    {
        private readonly Application _app;
        private readonly ContainerBuilder _builder;
        private readonly IDictionary<Type, Type> _viewViewModelMaching = new Dictionary<Type, Type>();

        private IViewFactory _viewFactory;
        private Type _startPageViewModelType;
        private Type _menuPageViewModelType = null;
        private Page _startPageInstance = null;
        
        internal Func<string, string> ViewLocatorConvention { get; private set; } = (viewModelFullName) =>
            viewModelFullName?.Replace(".ViewModels.", ".Views.").Replace("ViewModel", string.Empty);
        internal Func<string, string> TabViewModelLocatorConvention { get; private set; } = (tabViewFullName) =>
            $"{tabViewFullName?.Replace(".Views.", ".ViewModels.")}ViewModel"; //.Replace("ViewModel", string.Empty);

        internal Bootstrapper(Application app)
        {
            _app = app;
            _builder = new ContainerBuilder();

            //Register AppConfig instance for check configs modes
            _builder.Register<IAppConfig>(context => new AppConfig(this, _app)).SingleInstance();

            _builder.RegisterModule<DependencyRegistrationModule>();
        }

        public IBootstrapper RegisterDependencies(Action<ContainerBuilder> actionToBuilder)
        {
            actionToBuilder(_builder);
            return this;
        }

        public IBootstrapper RegisterViews(Action<IRegisterView> register)
        {
            register(this);
            return this;
        }

        public IBootstrapper Configure(Action<IConfigurationOptions> config)
        {
            config(this);
            return this;
        }


        public void Build()
        {

            var container = _builder.Build();


            _viewFactory = container.Resolve<IViewFactory>();

            if (_viewViewModelMaching.Count > 0)
            {
                foreach (var k in _viewViewModelMaching.Keys)
                {
                    _viewFactory.Register(_viewViewModelMaching[k], k);
                }
            }

            if (_startPageInstance != null)
            {
                _app.MainPage = _startPageInstance;
            }

            else if (_menuPageViewModelType == null && _startPageViewModelType != null)
            {
                var principalPage = _viewFactory.Resolve(_startPageViewModelType);
                _app.MainPage = new NavigationPage(principalPage);
            }


            else if (_menuPageViewModelType != null) //if _menuPageViewModelType is set, will be use masterDetail Approach
            {
                var menuPage = _viewFactory.Resolve(_menuPageViewModelType);
                var principalPage = _viewFactory.Resolve(_startPageViewModelType);

                menuPage.Title = " ";
                try
                {
                    _app.MainPage = new MasterDetailPage()
                    {
                        Master = menuPage,
                        Detail = new NavigationPage(principalPage)

                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //  throw;
                }

            }
        }

        /// <summary>
        /// Allow match viewmodel with view avoid default convention
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public void RegisterView<TView, TViewModel>() where TViewModel : class, IViewModelBase where TView : Page
        {
            _viewViewModelMaching[typeof(TViewModel)] = typeof(TView);
        }


        #region ConfigureOptions

        public IConfigurationOptions SetStartupView<TViewModel>() where TViewModel : IViewModelBase
        {
            _startPageViewModelType = typeof(TViewModel);
            return this;
        }

        public IConfigurationOptions SetStartupView(Page pageInstance)
        {
            _startPageInstance = pageInstance ?? throw new NullReferenceException($"{nameof(pageInstance)} is null");
            return this;
        }

        public IConfigurationOptions SetViewLocatorConvention(Func<string, string> viewLocatorConvention)
        {
            ViewLocatorConvention = viewLocatorConvention;
            return this;
        }

        public IConfigurationOptions SetTabViewModelLocatorConvention(Func<string, string> tabViewModelLocatorConvention)
        {
            TabViewModelLocatorConvention = tabViewModelLocatorConvention;
            return this;
        }
        
        public IConfigurationOptions UseMasterDetailMode<TMenuViewModel>() where TMenuViewModel : IViewModelBase
        {
            _menuPageViewModelType = typeof(TMenuViewModel);
            return this;
        }


        public IConfigurationOptions UseMasterDetailMode<TMenuViewModel, TDetailViewModel>() where TMenuViewModel : IViewModelBase where TDetailViewModel : IViewModelBase
        {
            _startPageViewModelType = typeof(TDetailViewModel);
            _menuPageViewModelType = typeof(TMenuViewModel);
            return this;
        }


        #endregion




    }
}
