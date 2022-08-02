using System;
using System.Threading.Tasks;
using FluentAssertions;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Prism.Navigation;
using Prism.Services;
using Xunit;

namespace MarvelApp.Tests.ViewModels
{
    public class LandingViewModelTests
    {
        private readonly LandingViewModel _sut;
        private readonly INavigationService _navigationService = Substitute.For<INavigationService>();
        private readonly IPageDialogService _dialogService = Substitute.For<IPageDialogService>();
        private readonly IStartupService _startupService = Substitute.For<IStartupService>();

        public LandingViewModelTests()
        {
            _sut = new LandingViewModel(_navigationService, _dialogService, _startupService);
        }
        
        [Fact]
        public void OnNavigatedTo_Should_Call_Startup_Service()
        {
            //Arrange
            var parameters = new NavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _startupService.Received(1).SetDatabasePath();
        }
        
        [Fact]
        public void OnNavigatedTo_Should_Set_Progress()
        {
            //Arrange
            var parameters = new NavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _sut.Progress.Should().BeInRange(0.0, 1.0);
        }

        
        [Fact]
        public async Task OnNavigatedTo_Should_HandleError()
        {
            //Arrange
            _startupService.SetDatabasePath().Throws(new Exception());
            var parameters = new NavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            await _dialogService.Received(1).DisplayAlertAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
    }
}