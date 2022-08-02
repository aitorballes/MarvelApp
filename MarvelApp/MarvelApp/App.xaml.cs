using MarvelApp.Extensions;
using MarvelApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MarvelApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null!) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"/{nameof(LandingPage)}");
        }
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddViews();
            containerRegistry.AddServices();
        }
        
        #region App Lifecycle Events
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
     

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
        

      
    }
}