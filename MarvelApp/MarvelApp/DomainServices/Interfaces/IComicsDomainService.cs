using System.Threading.Tasks;
using MarvelApp.DomainServices.DTOs;
using Refit;

namespace MarvelApp.DomainServices.Interfaces
{
    public interface IComicsDomainService
    {
     
        
        [Get("/v1/public/comics?orderBy=-modified")]
        Task<ItemResponseDto> GetLastModifiedComics(
            [AliasAs("offset")] int offset, 
            [AliasAs("limit")] int limit, 
            [AliasAs("ts")] string timeStamp, 
            [AliasAs("apikey")] string apiKey, 
            [AliasAs("hash")] string hash);
        
        [Get("/v1/public/comics?orderBy=-modified")]
        Task<ItemResponseDto> GetLastModifiedComicsByTitle(
            [AliasAs("offset")] int offset, 
            [AliasAs("limit")] int limit, 
            [AliasAs("titleStartsWith")] string titleStart, 
            [AliasAs("ts")] string timeStamp, 
            [AliasAs("apikey")] string apiKey, 
            [AliasAs("hash")] string hash);
    }
}