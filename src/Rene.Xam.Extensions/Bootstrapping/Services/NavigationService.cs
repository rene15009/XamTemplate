using System;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewFactory;
        private readonly IAppConfig _appConfig;
        private INavigation Navigation => _navigation.Value;

        public NavigationService(Lazy<INavigation> navigation, IViewFactory viewFactory, IAppConfig appConfig)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
            _appConfig = appConfig;
        }

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopModalAsync()
        {
            await Navigation.PopModalAsync(false);
        }

        public async Task PopAllModalsAsync()
        {
            while (Navigation.ModalStack.Count > 0)
                await PopModalAsync();
        }


        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }
        private async Task PushWindow(Page view)
        {
            if (_appConfig.IsUsingMasterDetailMode)
            {
                //TODO: Resolve Android Back Button
                var masterDetail = ((MasterDetailPage)_appConfig.MainPage);
                masterDetail.Detail=new NavigationPage(view);

                _appConfig.ShowHideMenu(false);
            }
            else
            {
                await Navigation.PushAsync(view);
            }
        }
        public async Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {

            var view = _viewFactory.Resolve<TViewModel>();
            await PushWindow(view);

        }

        public async Task PushAsync<TViewModel, TKArguments>(TKArguments args) where TViewModel : class, IArgumentViewModel<TKArguments>
        {

            var view = _viewFactory.Resolve<TViewModel, TKArguments>(args);
            await PushWindow(view);

        }
        public async Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var view = _viewFactory.Resolve<TViewModel>();
            await Navigation.PushModalAsync(view);
        }

        public async Task PushAsync(Type viewModelType)
        {
            var view = _viewFactory.Resolve(viewModelType);
            await PushWindow(view);
        }

        public async Task PushAsync<TKArguments>(Type viewModelType, TKArguments args)
        {
            var view = _viewFactory.Resolve<TKArguments>(viewModelType, args);
            await PushWindow(view);
        }

        public async Task PushModalAsync<TViewModel, TKArguments>(TKArguments args) where TViewModel : class, IArgumentViewModel<TKArguments>
        {
            var view = _viewFactory.Resolve<TViewModel, TKArguments>(args);
            await Navigation.PushModalAsync(view);
        }
    }
}
