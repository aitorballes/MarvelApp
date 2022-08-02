using MarvelApp.DomainServices.DTOs.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarvelApp.DomainServices.DTOs
{
    public class ItemResponseDto
    {
        [JsonProperty("code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RestStatusCode Code { get; set; }
        [JsonProperty("data")]
        public ItemDataDto? Data { get; set; }
    }
}