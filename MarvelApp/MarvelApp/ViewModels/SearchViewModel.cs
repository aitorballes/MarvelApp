using System;
using System.Collections.ObjectModel;
using MarvelApp.Controls;
using MarvelApp.Models;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels.Base;
using MarvelApp.Views;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MarvelApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        
        private readonly IComicsService _comicsService;
        private readonly ISeriesService _seriesService;
        
        public DelegateCommand ChangeSearchTypeCommand { get; }
        public DelegateCommand SelectItemCommand { get; }
        public SearchViewModel(INavigationService navigationService, 
                                IPageDialogService dialogService,
                                IComicsService comicsService, 
                                ISeriesService seriesService) : base(navigationService, dialogService)
        {
            _comicsService = comicsService;
            _seriesService = seriesService;
            ChangeSearchTypeCommand = new DelegateCommand(ChangeSearchType).ObservesCanExecute(() => IsNotBusy);
            SelectItemCommand = new DelegateCommand(SelectItem);
        }
        #region Properties
        private ItemModel? _selectedItem;
        private string? _searchText;
        private ObservableCollection<ItemModel>? _items;
        private bool _comicsSearch = true;
        
        public ItemModel? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public string? SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
               
                Search(_searchText);
            }
        }

        public ObservableCollection<ItemModel>? Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public bool ComicsSearch
        {
            get => _comicsSearch;
            set => SetProperty(ref _comicsSearch, value);
        }

        #endregion

        private void ChangeSearchType()
        {
            ComicsSearch = !ComicsSearch;
        }

        private async void Search(string? searchText)
        {

            if (string.IsNullOrEmpty(searchText))
            {
                Items = null;
                return;
            }
            
            if (searchText?.Length > 3)
            {
                try
                {
                    IsBusy = true;

                    Items = new ObservableCollection<ItemModel>(ComicsSearch ? await _comicsService.GetLastModifiedComicsByTitle(0, 10, searchText) : await _seriesService.GetLastModifiedSeriesByTitle(0, 10, searchText));
                }
                catch (Exception e)
                {
                    await HandleError(nameof(SearchViewModel), e.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private async void SelectItem()
        {
            if(SelectedItem is null)
                return;
            
            IsBusy = true;

            var parameters = new NavigationParameters()
            {
                {NavigationConstants.ItemParameter, SelectedItem}
            };
            await NavigationService.NavigateAsync($"{nameof(TransitionNavigationPage)}/{nameof(ItemDetailPage)}", parameters);
            SelectedItem = null;
            IsBusy = false;
        }

      
    }
}