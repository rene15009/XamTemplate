using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Template.Samples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabsSamplePage : TabbedPage
    {
        public TabsSamplePage ()
        {
            var child = this.Children;
            InitializeComponent();
            var childs = this.Children;
        }
    }
}