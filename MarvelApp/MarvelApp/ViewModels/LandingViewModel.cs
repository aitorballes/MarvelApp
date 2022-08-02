using System;
using System.Threading.Tasks;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels.Base;
using MarvelApp.Views;
using Prism.Navigation;
using Prism.Services;

namespace MarvelApp.ViewModels
{
    public class LandingViewModel : ViewModelBase
    {
        private readonly IStartupService _startupService;
        public LandingViewModel(INavigationService navigationService, 
                                IPageDialogService dialogService,
                                IStartupService startupService) : base(navigationService, dialogService)
        {
            _startupService = startupService;
        }

        private double _progress;

        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                await _startupService.SetDatabasePath();
                await FakeLoadingProgress();
            }
            catch (Exception e)
            {
                await HandleError(e.Message);
            }
            
        }

        private async Task FakeLoadingProgress()
        {
            Progress = 0.25;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Progress = 0.50;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Progress = 0.75;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Progress = 1;

            await NavigationService.NavigateAsync($"/{nameof(RootPage)}");
        }
    }
}