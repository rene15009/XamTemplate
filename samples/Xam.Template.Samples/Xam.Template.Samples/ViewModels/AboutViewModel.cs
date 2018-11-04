using System;
using System.Windows.Input;
using Rene.Xam.Extensions.Base;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel()
        {
           // Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}