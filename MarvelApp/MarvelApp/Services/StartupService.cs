using System.Threading.Tasks;
using MarvelApp.Services.Interfaces;

namespace MarvelApp.Services
{
    public class StartupService : IStartupService
    {
        private readonly IDatabaseService _databaseService;
        private readonly IPathService _pathService;

        public StartupService(IDatabaseService databaseService, IPathService pathService)
        {
            _databaseService = databaseService;
            _pathService = pathService;
        }

        public async Task SetDatabasePath()
        {
            _databaseService.SetDatabasePath(_pathService.GetDatabasePath());
            await Task.CompletedTask;
        }
    }
}