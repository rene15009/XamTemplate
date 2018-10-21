using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Xam.Template.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        public AboutPageViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}