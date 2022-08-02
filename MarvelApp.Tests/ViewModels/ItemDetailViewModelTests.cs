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
using Xunit;

namespace MarvelApp.Tests.ViewModels
{
    public class ItemDetailViewModelTests
    {
        private readonly ItemDetailViewModel _sut;
        private readonly INavigationService _navigationService = Substitute.For<INavigationService>();
        private readonly IPageDialogService _dialogService = Substitute.For<IPageDialogService>();
        private readonly IDatabaseService _databaseService = Substitute.For<IDatabaseService>();

        public ItemDetailViewModelTests()
        {
            _sut = new ItemDetailViewModel(_navigationService, _dialogService, _databaseService);
        }

        [Fact]
        public void OnNavigatedTo_Should_Set_Item()
        {
            //Arrange
            var parameters = MockHelper.GetNavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _sut.Item.Should().BeEquivalentTo(MockHelper.GetItem());
        }
        
        [Fact]
        public void OnNavigatedTo_Should_Call_Database_Service()
        {
            //Arrange
            var parameters = MockHelper.GetNavigationParameters();
            //Act
            _sut.OnNavigatedTo(parameters);
            //Assert
            _databaseService.Received(1).CheckIfExist<ItemModel>(Arg.Any<int>());
        }

        [Fact]
        public async Task NavigateBackCommand_Should_GoBackAsync()
        {
            //Arrange
            
            //Act
            _sut.NavigateBackCommand.Execute();
            //Assert
            await _navigationService.Received(1).GoBackAsync();
        }

        [Fact]
        public void AddOrRemoveCommand_Should_Call_DeleteById_If_Is_Favourite()
        {
            //Arrange
            _sut.IsFavourite = true;
            //Act
            _sut.AddOrRemoveCommand.Execute();
            //Assert
            _databaseService.Received(1).DeleteById<ItemModel>(Arg.Any<int?>());
        }
        
        [Fact]
        public void AddOrRemoveCommand_Should_Call_UpsertElement_If_Is_Not_Favourite()
        {
            //Arrange
            _sut.IsFavourite = false;
            //Act
            _sut.AddOrRemoveCommand.Execute();
            //Assert
            _databaseService.Received(1).UpsertElement(Arg.Any<ItemModel>());
        }
        
        [Fact]
        public async Task AddOrRemoveCommand_Should_DisplayAlertAsync_If_Is_Favourite()
        {
            //Arrange
            _sut.IsFavourite = true;
            //Act
            _sut.AddOrRemoveCommand.Execute();
            //Assert
            await _dialogService.Received(1).DisplayAlertAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
        
        [Fact]
        public async Task AddOrRemoveCommand_Should_DisplayAlertAsync_If_Is_Not_Favourite()
        {
            //Arrange
            _sut.IsFavourite = false;
            //Act
            _sut.AddOrRemoveCommand.Execute();
            //Assert
            await _dialogService.Received(1).DisplayAlertAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
        
        [Fact]
        public async Task AddOrRemoveCommand_Should_HandleException()
        {
            //Arrange
            _sut.IsFavourite = true;
            _databaseService.DeleteById<ItemModel>(Arg.Any<int>()).Throws(new Exception());
            //Act
            _sut.AddOrRemoveCommand.Execute();
            //Assert
            await _dialogService.Received(1).DisplayAlertAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
   
    }
}