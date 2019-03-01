using System.ComponentModel;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
	public interface IViewModelBase 
	{

	}

    public interface IArgumentViewModel<in TArgument>: IViewModelBase
    {
        void FromPreviousPage(TArgument data);
    }

}
