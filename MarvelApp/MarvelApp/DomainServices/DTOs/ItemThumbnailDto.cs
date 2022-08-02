using Newtonsoft.Json;

namespace MarvelApp.DomainServices.DTOs
{
    public class ItemThumbnailDto
    {
        [JsonProperty("path")]
        public string? Path { get; set; }
        [JsonProperty("extension")]
        public string? Extension { get; set; }
        public string? Image => GetImage();

        private string? GetImage()
        {
            return !string.IsNullOrEmpty(Path) && !string.IsNullOrEmpty(Extension) ? $"{Path}.{Extension}" : null;
        }
    }
}