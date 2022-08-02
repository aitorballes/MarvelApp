using System;
using System.Threading.Tasks;
using FluentAssertions;
using MarvelApp.Models;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Prism.Navigation;
using Prism.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xunit;

namespace MarvelApp.Tests.ViewModels
{
    public class HomeViewModelTests
    {
        private readonly HomeViewModel _sut;
        private readonly INavigationService _navigationService = Substitute.For<INavigationService>();
        private readonly IPageDialogService _dialogService = Substitute.For<IPageDialogService>();
        private readonly IComicsService _comicsService = Substitute.For<IComicsService>();
        private readonly ISeriesService _seriesService = Substitute.For<ISeriesService>();

        public HomeViewModelTests()
        {
            _sut = new HomeViewModel(_navigationService, _dialogService, _comicsService, _seriesService);
        }

        [Fact]
        public async Task OnNavigatedTo_Should_Call_Needed_Services()
        {
            //Arrange
            var parameters = new NavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            await _comicsService.Received(1).GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>());
            await _seriesService.Received(1).GetLastModifiedSeries(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public void OnNavigatedTo_Should_Fill_Comics()
        {
            //Arrange
            var parameters = new NavigationParameters();
            _comicsService.GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>()).Returns(MockHelper.GetItems());
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _sut.Comics.Should().BeEquivalentTo(new ObservableRangeCollection<ItemModel>(MockHelper.GetItems()));
        }

        [Fact]
        public void OnNavigatedTo_Should_Fill_Series()
        {
            //Arrange
            var parameters = new NavigationParameters();
            _seriesService.GetLastModifiedSeries(Arg.Any<int>(), Arg.Any<int>()).Returns(MockHelper.GetItems());
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _sut.Series.Should().BeEquivalentTo(new ObservableRangeCollection<ItemModel>(MockHelper.GetItems()));
        }

        [Fact]
        public void OnNavigatedTo_Should_HandleError()
        {
            //Arrange
            var parameters = new NavigationParameters();
            _comicsService.GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>()).Throws(new Exception());
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _dialogService.Received(1).DisplayAlertAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void SelectItemCommand_Should_Reset_SelectedItem()
        {
            //Arrange
            _sut.SelectedItem = MockHelper.GetItem();
            //Act
            _sut.SelectItemCommand.Execute();

            //Assert
            _sut.SelectedItem.Should().BeNull();
        }

        [Fact]
        public void SelectItemCommand_Should_Navigate_To_ItemDetailPage()
        {
            //Arrange
            _sut.SelectedItem = MockHelper.GetItem();
            
            //Act
            _sut.SelectItemCommand.Execute();

            //Assert
            _navigationService.Received(1).NavigateAsync(Arg.Any<string>(),Arg.Any<NavigationParameters>());
        }

        [Fact]
        public async Task IsActive_Should_Call_Needed_Services()
        {
            //Arrange
            //Act
            _sut.IsActive = true;
            //Assert
            await _comicsService.Received(1).GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>());
            await _seriesService.Received(1).GetLastModifiedSeries(Arg.Any<int>(), Arg.Any<int>());
            ;
        }

        
    }
}