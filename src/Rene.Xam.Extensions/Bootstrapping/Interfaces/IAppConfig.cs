using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
    public interface IAppConfig
    {
        Page MainPage { get; }

        bool IsUsingMasterDetailMode { get; }

        void ShowHideMenu(bool show);

        //[Obsolete("No utilizar")]
        //void SetDetailPage(Page newView);

        Func<string, string> ViewLocatorConvention { get; }
        Func<string, string> TabViewModelLocatorConvention { get; }
    }
}
