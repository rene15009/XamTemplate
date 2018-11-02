using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.Modules;
using Rene.Xam.Extensions.Bootstrapping.Services;
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
        private bool _runedBuildContainer ;

        private readonly IDictionary<Type, Type> _viewViewModelMaching = new Dictionary<Type, Type>();

        private IViewFactory _viewFactory;
        private Type _startPageViewModelType;
        private Type _menuPageViewModelType = null;
        private Page _startPageInstance;



        internal Func<string, string> ViewLocatorConvention { get; } = (viewModelFullName) =>
            viewModelFullName?.Replace(".ViewModels.", ".Views.").Replace("ViewModel", string.Empty);


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

        public IBootstrapper Configuere(Action<IConfigurationOptions> config)
        {
            config(this);
            return this;
        }


        public void Build()
        {

            var container = _builder.Build();


            _runedBuildContainer = true;
            _viewFactory = container.Resolve<IViewFactory>();

            if (_viewViewModelMaching.Count > 0)
            {
                foreach (var k in _viewViewModelMaching.Keys)
                {
                    _viewFactory.Register(_viewViewModelMaching[k], k);
                }

                //    _viewViewModelMaching.Keys

            }


            if (_menuPageViewModelType == null && _startPageViewModelType != null)
            {
                var principalPage = _viewFactory.Resolve(_startPageViewModelType);
                _app.MainPage = new NavigationPage(principalPage);
            }


            if (_menuPageViewModelType != null) //if _menuPageViewModelType set will be use masterDetail Approach
            {
                var menuPage = _viewFactory.Resolve(_menuPageViewModelType);
                var principalPage = _viewFactory.Resolve(_startPageViewModelType);

                _app.MainPage = new MasterDetailPage()
                {
                    Master = menuPage,
                    Detail = new NavigationPage(principalPage)

                };
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


        public void SetStartupView<TViewModel>() where TViewModel : IViewModelBase
        {
            // https://forums.xamarin.com/discussion/47444/best-practice-mvvm-navigation-using-master-detail-page
            //https://github.com/adamped/xarch-starter
            _startPageViewModelType = typeof(TViewModel);
        }

        public void SetStartupView(Page pageInstance) =>
            _startPageInstance = pageInstance ?? throw new NullReferenceException($"{nameof(pageInstance)} is null");

        public void UseMasterDetailMode<TMenuViewModel>() where TMenuViewModel : IViewModelBase
        {
            _menuPageViewModelType = typeof(TMenuViewModel);
        }


        public void UseMasterDetailMode<TMenuViewModel, TDetailViewModel>() where TMenuViewModel : IViewModelBase where TDetailViewModel : IViewModelBase
        {
            _startPageViewModelType = typeof(TDetailViewModel);
            _menuPageViewModelType = typeof(TMenuViewModel);
        }



    }
}
