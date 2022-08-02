using System;
using MarvelApp.I18N;
using MarvelApp.Models;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MarvelApp.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly IDatabaseService _databaseService;
        public DelegateCommand NavigateBackCommand { get; }
        public DelegateCommand AddOrRemoveCommand { get; }

        public ItemDetailViewModel(INavigationService navigationService, IPageDialogService dialogService, IDatabaseService databaseService) : base(navigationService, dialogService)
        {
            _databaseService = databaseService;
            NavigateBackCommand = new DelegateCommand(NavigateBack).ObservesCanExecute(() => IsNotBusy);
            AddOrRemoveCommand = new DelegateCommand(AddOrRemove).ObservesCanExecute(() => IsNotBusy);
        }

        #region Properties
        private ItemModel _item = new ();
        private bool _isFavourite;

        public ItemModel Item
        {
            get => _item;
            private set => SetProperty(ref _item, value);
        }

        public bool IsFavourite
        {
            get => _isFavourite;
            set => SetProperty(ref _isFavourite, value);
        }
        #endregion

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var item = parameters.GetValue<ItemModel>(NavigationConstants.ItemParameter);
            if (item is not null)
            {
                Item = item;
                IsFavourite = _databaseService.CheckIfExist<ItemModel>(Item.Id);
            }
        }

        private async void NavigateBack()
        {
            IsBusy = true;

            await NavigationService.GoBackAsync();

            IsBusy = false;
        }

        private async void AddOrRemove()
        {
            try
            {
                IsBusy = true;

                if (IsFavourite)
                {
                    _ = _databaseService.DeleteById<ItemModel>(Item.Id);

                    await DialogService.DisplayAlertAsync(AppTexts.ItemDetailPage_SuccessDialog_Title, AppTexts.ItemDetailPage_SuccessDialog_RemovedMessage, AppTexts.Ok_Button_Label);
                }
                else
                {
                    _databaseService.UpsertElement(Item);

                    await DialogService.DisplayAlertAsync(AppTexts.ItemDetailPage_SuccessDialog_Title, AppTexts.ItemDetailPage_SuccessDialog_AddedMessage, AppTexts.Ok_Button_Label);
                }

                IsFavourite = !IsFavourite;
            }
            catch (Exception e)
            {
                await HandleError(e.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}