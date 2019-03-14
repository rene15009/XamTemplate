using System;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
	public interface INavigationService
	{
		Task PopAsync();
	    Task PopModalAsync();
	    Task PopAllModalsAsync();
        Task PopToRootAsync();
		Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
		Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
        Task PushModalAsync<TViewModel, KArguments>(KArguments args) where TViewModel : class, IArgumentViewModel<KArguments>;
        Task PushAsync<TViewModel, KArguments>(KArguments args) where TViewModel : class, IArgumentViewModel<KArguments>;

        Task PushAsync(Type viewModelType);

        Task PushAsync<KArguments>(Type viewModelType, KArguments args);
    }
}
