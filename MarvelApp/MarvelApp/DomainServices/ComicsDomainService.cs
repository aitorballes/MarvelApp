using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.DomainServices.Interfaces;
using Refit;

namespace MarvelApp.DomainServices
{
    public class ComicsDomainService : IComicsDomainService
    {
        private readonly IComicsDomainService _service;

        public ComicsDomainService()
        {
            _service = RestService.For<IComicsDomainService>(ApiConstants.BaseUrl);
        }

        public async Task<ItemResponseDto> GetLastModifiedComics(int offset, int limit, string timeStamp, string apiKey, string hash)
        {
            return await _service.GetLastModifiedComics(offset, limit, timeStamp, apiKey, hash);
        }

        public async Task<ItemResponseDto> GetLastModifiedComicsByTitle(int offset, int limit, string titleStart, string timeStamp, string apiKey, string hash)
        {
            return await _service.GetLastModifiedComicsByTitle(offset, limit, titleStart, timeStamp, apiKey, hash);
        }
    }
}