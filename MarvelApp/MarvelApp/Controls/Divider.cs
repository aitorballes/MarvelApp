using Xamarin.Forms;

namespace MarvelApp.Controls
{
    public class Divider : BoxView
    {
        public Divider()
        {
            HeightRequest = 1;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            BackgroundColor = Theme.DividerColor;
        }
    }
}