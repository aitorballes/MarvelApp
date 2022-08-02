using System;
using System.Threading.Tasks;
using MarvelApp.I18N;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace MarvelApp.ViewModels.Base
{
    public class ViewModelBase :  BindableBase, INavigationAware, IDestructible, IApplicationLifecycleAware
    {
        protected readonly INavigationService NavigationService;
        protected readonly IPageDialogService DialogService;
        
        public ViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool IsNotBusy => !IsBusy;
        protected async Task HandleError(string context, string? message = null)
        {
            await DialogService.DisplayAlertAsync(AppTexts.HandleErrorDialog_Title, 
                string.IsNullOrEmpty(message) ? AppTexts.HandleErrorDialog_Message : message, 
                AppTexts.Ok_Button_Label);
            
            Console.Write($@"Error: {message}, Stack trace: {context} ");
        }

        public virtual void Destroy()
        {
            //throw new NotImplementedException();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnResume()
        {
            //throw new System.NotImplementedException();
        }

        public virtual void OnSleep()
        {
            //throw new System.NotImplementedException();
        }
    }
}