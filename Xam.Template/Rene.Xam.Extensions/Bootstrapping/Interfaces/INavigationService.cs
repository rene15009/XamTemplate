using System.Threading.Tasks;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
	public interface INavigationService
	{
		Task PopAsync();
		Task PopToRootAsync();
		Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
		Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
	}
}
