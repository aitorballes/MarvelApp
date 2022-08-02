using Xamarin.Forms;

namespace MarvelApp
{
    public static class Theme
    {
        #region Spacings

        public static double SmallSpacing = 8.0;
        public static double MediumSpacing = 12.0;
        public static double StandardSpacing = 26.0;
        public static double LargeSpacing = 38.0;
        public static double InterlineSpacing = 5.0;

        #endregion

        #region Paddings

        public static Thickness SmallPadding = new(SmallSpacing);
        public static Thickness MediumPadding = new(MediumSpacing);
        public static Thickness StandardPadding = new(StandardSpacing);
        public static Thickness LargePadding = new(LargeSpacing);

        public static Thickness SmallVerticalPadding = new Thickness(0, SmallSpacing);
        public static Thickness MediumVerticalPadding = new Thickness(0, MediumSpacing);
        public static Thickness StandardVerticalPadding = new Thickness(0, StandardSpacing);
        public static Thickness LargeVerticalPadding = new Thickness(0, LargeSpacing);

        public static Thickness SmallHorizontalPadding = new Thickness(SmallSpacing, 0);
        public static Thickness MediumHorizontalPadding = new Thickness(MediumSpacing, 0);
        public static Thickness StandardHorizontalPadding = new Thickness(StandardSpacing, 0);
        public static Thickness LargeHorizontalPadding = new Thickness(LargeSpacing, 0);

        public static Thickness SmallLeftPadding = new Thickness(SmallSpacing, 0, 0, 0);
        public static Thickness MediumLeftPadding = new Thickness(MediumSpacing, 0, 0, 0);
        public static Thickness StandardLeftPadding = new Thickness(StandardSpacing, 0, 0, 0);
        public static Thickness LargeLeftPadding = new Thickness(LargeSpacing, 0, 0, 0);

        public static Thickness SmallTopPadding = new Thickness(0, SmallSpacing, 0, 0);
        public static Thickness MediumTopPadding = new Thickness(0, MediumSpacing, 0, 0);
        public static Thickness StandardTopPadding = new Thickness(0, StandardSpacing, 0, 0);
        public static Thickness LargeTopPadding = new Thickness(0, LargeSpacing, 0, 0);

        public static Thickness SmallRightPadding = new Thickness(0, 0, SmallSpacing, 0);
        public static Thickness MediumRightPadding = new Thickness(0, 0, MediumSpacing, 0);
        public static Thickness StandardRightPadding = new Thickness(0, 0, StandardSpacing, 0);
        public static Thickness LargeRightPadding = new Thickness(0, 0, LargeSpacing, 0);

        public static Thickness SmallBottomPadding = new Thickness(0, 0, 0, SmallSpacing);
        public static Thickness MediumBottomPadding = new Thickness(0, 0, 0, MediumSpacing);
        public static Thickness StandardBottomPadding = new Thickness(0, 0, 0, StandardSpacing);
        public static Thickness LargeBottomPadding = new Thickness(0, 0, 0, LargeSpacing);

        #endregion

        #region Colors

        public static Color PageBackgroundColor = Color.FromHex("1E1C1C");
        public static Color LandingPageBackgroundColor = Color.Black;
        public static Color TabBarBackgroundColor = Color.Black;
        public static Color PrimaryColor = Color.White;
        public static Color PrimaryContrastColor = Color.Black;
        public static Color SecondaryColor = Color.LightSlateGray;
        public static Color DividerColor = Color.White;
        public static Color FrameBackGroundColor = Color.Black;
        public static Color SearchEntryBackGroundColor = Color.Black;
        
        

        #endregion
        
        #region Fonts
        public static double MiniFont =12.0;
        public static double SmallFont = 14.0;
        public static double NormalFont = 18.0;
        public static double MediumFont = 20.0;
        public static double LargeFont = 24.0;
        #endregion
        
        #region Buttons
        public static readonly double PrimaryButtonHeight = 32.0;
        public static readonly double PrimaryButtonFontSize = MiniFont;
        public static readonly int PrimaryButtonCornerRadius = 4;
        public static readonly double PrimaryButtonBorderWidth = 0.0;
        public static readonly Color PrimaryButtonBorderColor = PrimaryColor;
        public static readonly Color PrimaryButtonBackgroundColor = PrimaryColor;
        public static readonly Color PrimaryButtonTextColor = PrimaryContrastColor;
        public static readonly double PrimaryButtonDisabledOpacity = 0.5;

        public static readonly double LinkButtonHeight = NormalFont;
        public static readonly double LinkButtonDisabledOpacity = 0.5;
        public static Color LinkButtonTextColor = SecondaryColor;
        public static Color LinkButtonBackgroundColor = Color.Transparent;

        #endregion
    }
}