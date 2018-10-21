using Xamarin.Forms;

namespace Rene.Xam.Extensions.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty IsBorderErrorVisibleProperty = BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(CustomEntry), false, BindingMode.OneWay);

        public bool IsBorderErrorVisible
        {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set
            {
                SetValue(IsBorderErrorVisibleProperty, value);
            }
        }

        public static readonly BindableProperty BorderErrorColorProperty = BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Transparent, BindingMode.OneWay);

        public Xamarin.Forms.Color BorderErrorColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
            set
            {
                SetValue(BorderErrorColorProperty, value);
            }
        }


    }
}
