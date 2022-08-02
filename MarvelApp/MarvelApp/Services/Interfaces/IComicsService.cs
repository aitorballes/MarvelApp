using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelApp.Models;

namespace MarvelApp.Services.Interfaces
{
    public interface IComicsService
    {
        Task<IEnumerable<ItemModel>> GetLastModifiedComics(int offset, int limit);
        Task<IEnumerable<ItemModel>> GetLastModifiedComicsByTitle(int offset, int limit, string titleStart);
    }
}