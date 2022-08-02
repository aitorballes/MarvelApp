using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using Refit;

namespace MarvelApp.DomainServices.Interfaces
{
    public interface ISeriesDomainService
    {
        [Get("/v1/public/series?orderBy=-modified")]
        Task<ItemResponseDto> GetLastModifiedSeries(
            [AliasAs("offset")] int offset, 
            [AliasAs("limit")] int limit, 
            [AliasAs("ts")] string timeStamp, 
            [AliasAs("apikey")] string apiKey, 
            [AliasAs("hash")] string hash);
        
        [Get("/v1/public/series?orderBy=-modified")]
        Task<ItemResponseDto> GetLastModifiedSeriesByTitle(
            [AliasAs("offset")] int offset, 
            [AliasAs("limit")] int limit, 
            [AliasAs("titleStartsWith")] string titleStart, 
            [AliasAs("ts")] string timeStamp, 
            [AliasAs("apikey")] string apiKey, 
            [AliasAs("hash")] string hash);
    }
}