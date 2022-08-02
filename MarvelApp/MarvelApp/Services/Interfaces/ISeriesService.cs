using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelApp.Models;

namespace MarvelApp.Services.Interfaces
{
    public interface ISeriesService
    {
        Task<IEnumerable<ItemModel>> GetLastModifiedSeries(int offset, int limit);
        
        Task<IEnumerable<ItemModel>> GetLastModifiedSeriesByTitle(int offset, int limit, string titleStart);

    }
}