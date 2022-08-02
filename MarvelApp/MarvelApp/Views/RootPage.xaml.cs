using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage
    {
        public RootPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetTranslucencyMode(TranslucencyMode.Opaque);
            InitializeComponent();
        }
    }
}