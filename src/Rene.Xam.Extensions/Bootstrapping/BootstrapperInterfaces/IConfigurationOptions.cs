using System;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces
{
    public interface IConfigurationOptions
    {
        /// <summary>
        /// Set initial start view.
        /// </summary>
        /// <typeparam name="TViewModel">Start Page ViewModel</typeparam>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions SetStartupView<TViewModel>() where TViewModel : IViewModelBase;

        /// <summary>
        /// Set initial start view.
        /// </summary>
        /// <param name="pageInstance">Start Page Instance</param>
        /// <remarks>Use this method if you don't use MVVM pattern</remarks>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions SetStartupView(Page pageInstance);


        /// <summary>
        /// Set MasterDetail mode
        /// </summary>
        /// <typeparam name="TMenuViewModel">Menu View Model</typeparam>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions UseMasterDetailMode<TMenuViewModel>() where TMenuViewModel : IViewModelBase;

        /// <summary>
        /// Set MasterDetail mode
        /// </summary>
        /// <typeparam name="TMenuViewModel"></typeparam>
        /// <typeparam name="TDetailViewModel"></typeparam>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions UseMasterDetailMode<TMenuViewModel, TDetailViewModel>()
            where TMenuViewModel : IViewModelBase
            where TDetailViewModel : IViewModelBase;

        /// <summary>
        /// Set view locator convention to resolve view type from viewmodel.
        /// </summary>
        /// <param name="viewLocatorConvention">view locator convention</param>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions SetViewLocatorConvention(Func<string, string> viewLocatorConvention);

        /// <summary>
        /// Set viewModel locator convention to resolver tabViewmodel echa Tab (chil control) in TabbetPage
        /// </summary>
        /// <param name="tabViewModelLocatorConvention">viewModel locator convention</param>
        /// <returns>IConfigurationOptions to use fluent interface approach </returns>
        IConfigurationOptions SetTabViewModelLocatorConvention(Func<string, string> tabViewModelLocatorConvention);

    }
}