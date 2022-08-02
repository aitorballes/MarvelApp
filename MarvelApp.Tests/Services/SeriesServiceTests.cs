using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.DomainServices.Interfaces;
using MarvelApp.Services;
using NSubstitute;
using Xunit;

namespace MarvelApp.Tests.Services
{
    public class SeriesServiceTests
    {
        private readonly SeriesService _sut;
        private readonly ISeriesDomainService _domainService = Substitute.For<ISeriesDomainService>();


        public SeriesServiceTests()
        {
            _sut = new SeriesService(_domainService);
        }
        
        [Fact]
        public async Task GetLastModifiedSeries_Should_Call_SeriesDomainService_GetLastModifiedSeries()
        {
            //Arrange
            _domainService.GetLastModifiedSeries(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(MockHelper.GetItemResponseDto());
            //Act
            await _sut.GetLastModifiedSeries(0,5);
            //Assert
            await _domainService.Received(1).GetLastModifiedSeries(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
        
        [Fact]
        public async Task GetLastModifiedSeriesByTitle_Should_Call_SeriesDomainService_GetLastModifiedSeriesByTitle()
        {
            //Arrange
            _domainService.GetLastModifiedSeriesByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(),Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(MockHelper.GetItemResponseDto());
            //Act
            await _sut.GetLastModifiedSeriesByTitle(0,5,"ant");
            //Assert
            await _domainService.Received(1).GetLastModifiedSeriesByTitle(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(),Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

    }
}