using Rene.Xam.Extensions.Controls;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Behaviors
{
    public class RequiredValidatorBehavior : Behavior<CustomEntry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsVisibleError", typeof(bool), typeof(RequiredValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsVisibleError
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(CustomEntry entry)
        {
            entry.Unfocused += Unfocused;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(CustomEntry entry)
        {
            entry.Unfocused -= Unfocused;
            base.OnDetachingFrom(entry);
        }

        private void Unfocused(object sender, FocusEventArgs e)
        {
            
            IsVisibleError = false;
            var entry = (CustomEntry)sender;
            IsVisibleError = false;
            entry.IsBorderErrorVisible = false;

            if (string.IsNullOrEmpty(entry.Text))
            {
                IsVisibleError = true;
                entry.IsBorderErrorVisible = true;
            } 
            
        }

       
    
    }
}
