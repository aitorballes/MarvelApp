using MarvelApp.Controls;
using MarvelApp.DomainServices;
using MarvelApp.DomainServices.Interfaces;
using MarvelApp.Services;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels;
using MarvelApp.Views;
using Prism.Ioc;

namespace MarvelApp.Extensions
{
    public static class ContainerRegistryExtensions
    {
        public static void AddViews(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<LandingPage, LandingViewModel>();
            containerRegistry.RegisterForNavigation<RootPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>();
            containerRegistry.RegisterForNavigation<FavouritesPage, FavouritesViewModel>();
            containerRegistry.RegisterForNavigation<ItemDetailPage, ItemDetailViewModel>();
        }

        public static void AddServices(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
            containerRegistry.RegisterSingleton<IStartupService, StartupService>();
            containerRegistry.RegisterSingleton<IComicsDomainService, ComicsDomainService>();
            containerRegistry.RegisterSingleton<IComicsService, ComicsService>();
            containerRegistry.RegisterSingleton<ISeriesDomainService, SeriesDomainService>();
            containerRegistry.RegisterSingleton<ISeriesService, SeriesService>();
        }
    }
}
