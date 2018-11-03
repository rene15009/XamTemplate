using System.ComponentModel;
using Rene.Xam.Extensions.Base;
using Xamarin.Forms;

using Xam.Template.Samples.Models;
using Xam.Template.Samples.Services;

namespace Xam.Template.Samples.ViewModels
{
    public class BaseViewModel : ViewModelBase, INotifyPropertyChanged
    {
     //   public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

   
    }
}
