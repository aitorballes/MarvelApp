using Newtonsoft.Json;

namespace MarvelApp.DomainServices.DTOs
{
    public class ItemDataDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("results")]
        public ItemDto[]? Results { get; set; }
    }
}