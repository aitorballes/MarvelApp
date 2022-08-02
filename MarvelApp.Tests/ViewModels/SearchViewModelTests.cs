using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
    public class SearchViewModelTests
    {
        private readonly SearchViewModel _sut;
        private readonly INavigationService _navigationService = Substitute.For<INavigationService>();
        private readonly IPageDialogService _dialogService = Substitute.For<IPageDialogService>();
        private readonly IComicsService _comicsService = Substitute.For<IComicsService>();
        private readonly ISeriesService _seriesService = Substitute.For<ISeriesService>();

        public SearchViewModelTests()
        {
            _sut = new SearchViewModel(_navigationService, _dialogService, _comicsService, _seriesService);
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
        public void SearchText_Should_Fill_Items()
        {
            //Arrange
            _sut.ComicsSearch = true;
            _comicsService.GetLastModifiedComicsByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>()).Returns(MockHelper.GetItems());
            //Act
            _sut.SearchText = MockHelper.GetSearchText();
            //Assert
            _sut.Items.Should().BeEquivalentTo(new ObservableCollection<ItemModel>(MockHelper.GetItems()));
        }
        
        [Fact]
        public async Task SearchText_Should_Call_Comics_Service()
        {
            //Arrange
            _sut.ComicsSearch = true;
            //Act
            _sut.SearchText = MockHelper.GetSearchText();
            //Assert
            await _comicsService.Received(1).GetLastModifiedComicsByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>());
        }
        
        [Fact]
        public async Task SearchText_Should_Call_Series_Service()
        {
            //Arrange
            _sut.ComicsSearch = false;
            //Act
            _sut.SearchText = MockHelper.GetSearchText();
            //Assert
            await _seriesService.Received(1).GetLastModifiedSeriesByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>());
        }

      
    }
}