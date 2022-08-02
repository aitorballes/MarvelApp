using System.Threading.Tasks;

namespace MarvelApp.Services.Interfaces
{
    public interface IStartupService
    {
        Task SetDatabasePath();
    }
}