using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MarvelApp.Controls;
using MarvelApp.Models;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels.Base;
using MarvelApp.Views;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MarvelApp.ViewModels
{
    public class HomeViewModel : ViewModelBase, IActiveAware
    {
        private readonly IComicsService _comicsService;
        private readonly ISeriesService _seriesService;
        public DelegateCommand SelectItemCommand { get; }
        
        public HomeViewModel(INavigationService navigationService, IPageDialogService dialogService, IComicsService comicsService, ISeriesService seriesService) : base(navigationService, dialogService)
        {
            _comicsService = comicsService;
            _seriesService = seriesService;
            SelectItemCommand = new DelegateCommand(SelectItem).ObservesCanExecute(() => IsNotBusy);
        }

        #region Properties
        private ObservableRangeCollection<ItemModel> _comics = new();
        private ObservableRangeCollection<ItemModel> _series = new();
        private ItemModel? _selectedItem;
        private bool _isLoaded;
        private bool _isActive;
        public bool IsLoaded
        {
            get => _isLoaded;
            set => SetProperty(ref _isLoaded, value);
        }

        public ObservableRangeCollection<ItemModel> Comics
        {
            get => _comics;
            set => SetProperty(ref _comics, value);
        }

        public ObservableRangeCollection<ItemModel> Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        } 


        public ItemModel? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
        
        public event EventHandler IsActiveChanged;

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }

        #endregion

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;

                Series.AddRange(await _seriesService.GetLastModifiedSeries(0, 5));
                Comics.AddRange(await _comicsService.GetLastModifiedComics(0, 5));
                IsLoaded = true;

            }
            catch (Exception e)
            {
                await HandleError(nameof(HomeViewModel), e.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void SelectItem()
        {
            if (SelectedItem is null)
                return;

            IsBusy = true;

            var parameters = new NavigationParameters() { { NavigationConstants.ItemParameter, SelectedItem } };
            await NavigationService.NavigateAsync($"{nameof(TransitionNavigationPage)}/{nameof(ItemDetailPage)}", parameters);
            SelectedItem = null;
            IsBusy = false;
        }

        protected virtual async void RaiseIsActiveChanged()
        {
            await LoadData();
        }
    }
}