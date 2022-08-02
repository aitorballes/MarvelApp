using Xamarin.Forms;

namespace MarvelApp.Controls
{
    public class DividerVertical : BoxView
    {
        public DividerVertical()
        {
            WidthRequest = 1;
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.Start;
            BackgroundColor = Theme.DividerColor;
        }
    }
}