using System.IO;
using Android.OS;
using MarvelApp.Services.Interfaces;

namespace MarvelApp.Android.Services
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), AppSettings.DatabaseName);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            return path;
        }
    }
}