using Xamarin.Forms;

namespace MarvelApp.Controls
{
    public class CustomActivityIndicator : ContentView
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(CustomActivityIndicator), Color.Default);
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public CustomActivityIndicator()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            var indicator = new ActivityIndicator
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BindingContext = this
            };
            indicator.SetBinding(ActivityIndicator.ColorProperty, nameof(Color));
            indicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(IsVisible));
            Content = indicator;
        }
    }
}