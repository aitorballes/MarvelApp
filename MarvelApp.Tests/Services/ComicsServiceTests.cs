using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.DomainServices.Interfaces;
using MarvelApp.Services;
using NSubstitute;
using Xunit;

namespace MarvelApp.Tests.Services
{
    public class ComicsServiceTests
    {
        private readonly ComicsService _sut;
        private readonly IComicsDomainService _domainService = Substitute.For<IComicsDomainService>();


        public ComicsServiceTests()
        {
            _sut = new ComicsService(_domainService);
        }

        [Fact]
        public async Task GetLastModifiedComics_Should_Call_ComicsDomainService_GetLastModifiedComics()
        {
            //Arrange
            _domainService.GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(MockHelper.GetItemResponseDto());
            //Act
            await _sut.GetLastModifiedComics(0,5);
            //Assert
            await _domainService.Received(1).GetLastModifiedComics(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
        
        [Fact]
        public async Task GetLastModifiedComicsByTitle_Should_Call_ComicsDomainService_GetLastModifiedComicsByTitle()
        {
            //Arrange
            _domainService.GetLastModifiedComicsByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(),Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(MockHelper.GetItemResponseDto());
            //Act
            await _sut.GetLastModifiedComicsByTitle(0,5,"ant");
            //Assert
            await _domainService.Received(1).GetLastModifiedComicsByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(),Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

    }
}