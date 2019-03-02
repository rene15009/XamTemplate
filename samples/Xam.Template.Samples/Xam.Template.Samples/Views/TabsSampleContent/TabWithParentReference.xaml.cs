using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Template.Samples.Views.TabsSampleContent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabWithParentReference : ContentPage
	{
		public TabWithParentReference ()
		{
			InitializeComponent ();
		}
	}
}