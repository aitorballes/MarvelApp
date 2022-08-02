using System.Collections.ObjectModel;
using FluentAssertions;
using MarvelApp.Models;
using MarvelApp.Services.Interfaces;
using MarvelApp.ViewModels;
using NSubstitute;
using Prism.Navigation;
using Prism.Services;
using Xunit;

namespace MarvelApp.Tests.ViewModels
{
    public class FavouritesViewModelTests
    {
        private readonly FavouritesViewModel _sut;
        private readonly INavigationService _navigationService = Substitute.For<INavigationService>();
        private readonly IPageDialogService _dialogService = Substitute.For<IPageDialogService>();
        private readonly IDatabaseService _databaseService = Substitute.For<IDatabaseService>();

        public FavouritesViewModelTests()
        {
            _sut = new FavouritesViewModel(_navigationService, _dialogService, _databaseService);
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
        public void OnNavigatedTo_Should_Set_Item()
        {
            //Arrange
            var parameters = new NavigationParameters();
            _databaseService.GetAllElements<ItemModel>().Returns(MockHelper.GetItems());
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _sut.Items.Should().BeEquivalentTo( new ObservableCollection<ItemModel>(MockHelper.GetItems()));
        }
        
        [Fact]
        public void OnNavigatedTo_Should_Call_GetAllElements()
        {
            //Arrange
            var parameters = new NavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _databaseService.Received(1).GetAllElements<ItemModel>();
        }

        [Fact]
        public void IsActive_Should_Set_Items()
        {
            //Arrange
            _databaseService.GetAllElements<ItemModel>().Returns(MockHelper.GetItems());
            //Act
            _sut.IsActive = true;
            //Assert
            _sut.Items.Should().BeEquivalentTo( new ObservableCollection<ItemModel>(MockHelper.GetItems()));
        }
        
        [Fact]
        public void IsActive_Should_Call_GetAllElements()
        {
            //Arrange
            //Act
            _sut.IsActive = true;
            //Assert
            _databaseService.Received(1).GetAllElements<ItemModel>();
        }

    }
}