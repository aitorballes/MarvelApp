using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MarvelApp.Android.Services;
using MarvelApp.Services.Interfaces;
using Prism;
using Prism.Ioc;

namespace MarvelApp.Android
{
    [Activity(
        Label = "MarvelApp", 
        Theme = "@style/MainTheme", 
        Icon = "@mipmap/icon",
        RoundIcon = "@mipmap/icon_rounded",
        ScreenOrientation = ScreenOrientation.Portrait,
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new PlatformInitialized()));
        }
        
        public class PlatformInitialized : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterSingleton<IPathService, PathService>();

            }
        }
    }
}