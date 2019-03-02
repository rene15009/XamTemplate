namespace Rene.Xam.Extensions.Bootstrapping.ViewContracts
{
	public interface IViewModelBase 
	{

	}

    public interface IArgumentViewModel<in TArgument>: IViewModelBase
    {
        void FromPreviousPage(TArgument data);
    }

}
