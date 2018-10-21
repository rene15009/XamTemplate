using Xamarin.Forms;

namespace Rene.Xam.Extensions.Controls
{
    /// <summary>
    /// Custom render para IOS para que los bordes del listado no se pinten en los items sin elementos
    /// </summary>
    public class CustomListView : ListView
    {

        //public static readonly BindableProperty ItemsProperty =
        //    BindableProperty.Create("Items", typeof(IEnumerable<>), typeof(CustomListView), new List<object>());

        //public IEnumerable<DataSource> Items
        //{
        //    get { return (IEnumerable<DataSource>)GetValue(ItemsProperty); }
        //    set { SetValue(ItemsProperty, value); }
        //}

        //public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        //public void NotifyItemSelected(object item)
        //{
        //    if (ItemSelected != null)
        //    {
        //        ItemSelected(this, new SelectedItemChangedEventArgs(item));
        //    }
        //}

    }
}
