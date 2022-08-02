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
    public class FavouritesViewModel : ViewModelBase, IActiveAware
    {
        private readonly IDatabaseService _databaseService;
        public DelegateCommand SelectItemCommand { get; }

        public FavouritesViewModel(INavigationService navigationService, IPageDialogService dialogService, IDatabaseService databaseService) : base(navigationService, dialogService)
        {
            _databaseService = databaseService;
            SelectItemCommand = new DelegateCommand(SelectItem).ObservesCanExecute(() => IsNotBusy);
        }

        #region Properties
        private bool _isActive;
        private ItemModel? _selectedItem;
        private ObservableCollection<ItemModel>? _items;

        public ItemModel? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }


        public ObservableCollection<ItemModel>? Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        
        public event EventHandler IsActiveChanged;

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }

        #endregion
        
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadData();
        }

        private void LoadData()
        {
            Items = new ObservableCollection<ItemModel>(_databaseService.GetAllElements<ItemModel>());
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

      
        protected virtual  void RaiseIsActiveChanged()
        {
            LoadData();
        }
    }
}