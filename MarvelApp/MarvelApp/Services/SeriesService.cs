using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelApp.DomainServices.Interfaces;
using MarvelApp.Models;
using MarvelApp.Models.Mappers;
using MarvelApp.Services.Interfaces;

namespace MarvelApp.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesDomainService _domainService;

        public SeriesService(ISeriesDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<IEnumerable<ItemModel>> GetLastModifiedSeries(int offset, int limit)
        {
            var result = new List<ItemModel>();
            var comicResponse = await _domainService.GetLastModifiedSeries(offset, limit, ApiConstants.TimeStamp, ApiConstants.ApiKey, ApiConstants.Hash);

            if (comicResponse.Data?.Results?.Length > 0)
            {
                result.AddRange(comicResponse.Data.Results.Select(ItemMapper.MapFromDtoToModel));
            }

            return result;
        }
        
        public async Task<IEnumerable<ItemModel>> GetLastModifiedSeriesByTitle(int offset, int limit, string titleStart)
        {
            var result = new List<ItemModel>();
            var comicResponse = await _domainService.GetLastModifiedSeriesByTitle(offset, limit,titleStart, ApiConstants.TimeStamp, ApiConstants.ApiKey, ApiConstants.Hash);

            if (comicResponse.Data?.Results?.Length > 0)
            {
                result.AddRange(comicResponse.Data.Results.Select(ItemMapper.MapFromDtoToModel));
            }

            return result;
        }
    }
}