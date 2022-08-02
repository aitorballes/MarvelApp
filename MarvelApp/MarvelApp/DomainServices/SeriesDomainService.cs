using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.DomainServices.Interfaces;
using Refit;

namespace MarvelApp.DomainServices
{
    public class SeriesDomainService : ISeriesDomainService
    {
        private readonly ISeriesDomainService _service;

        public SeriesDomainService()
        {
            _service = RestService.For<ISeriesDomainService>(ApiConstants.BaseUrl);
        }

        public async Task<ItemResponseDto> GetLastModifiedSeries(int offset, int limit, string timeStamp, string apiKey, string hash)
        {
            return await _service.GetLastModifiedSeries(offset, limit, timeStamp, apiKey, hash);
        }

        public async Task<ItemResponseDto> GetLastModifiedSeriesByTitle(int offset, int limit, string titleStart, string timeStamp, string apiKey, string hash)
        {
            return await _service.GetLastModifiedSeriesByTitle(offset, limit, titleStart, timeStamp, apiKey, hash);
        }
    }
}