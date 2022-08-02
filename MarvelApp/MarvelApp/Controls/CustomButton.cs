using Xamarin.Forms;

namespace MarvelApp.Controls
{
    public class CustomButton : Button
    {
        public static readonly BindableProperty UppercaseProperty = BindableProperty.Create(nameof(Uppercase), typeof(bool), typeof(CustomButton), true);
        public bool Uppercase
        {
            get => (bool)GetValue(UppercaseProperty);
            set => SetValue(UppercaseProperty, value);
        }

        public static readonly BindableProperty HorizontalTextOptionsProperty = BindableProperty.Create(nameof(HorizontalTextOptions), typeof(TextAlignment), typeof(CustomButton), TextAlignment.Center);
        public TextAlignment HorizontalTextOptions
        {
            get => (TextAlignment)GetValue(HorizontalTextOptionsProperty);
            set => SetValue(HorizontalTextOptionsProperty, value);
        }

        public static readonly BindableProperty ImageTintColorProperty = BindableProperty.Create(nameof(ImageTintColor), typeof(Color), typeof(CustomButton), Color.Transparent); // off by default

        public Color ImageTintColor
        {
            get => (Color)GetValue(ImageTintColorProperty);
            set => SetValue(ImageTintColorProperty, value);
        }

    }
}