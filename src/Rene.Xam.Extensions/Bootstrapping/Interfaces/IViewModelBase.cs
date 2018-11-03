using System.ComponentModel;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
	public interface IViewModelBase : INotifyPropertyChanged
	{
	}

    public interface IArgumentViewModel<in TArgument>
    {
        void OnDataFromCaller(TArgument data);
    }

    public interface IArgumentViewModel : IArgumentViewModel<object>
    {

    }
}
