using System;
using System.Globalization;
using MarvelApp.I18N;
using Newtonsoft.Json;

namespace MarvelApp.DomainServices.DTOs
{
    public class ItemDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("format")]
        public string? Format { get; set; }
        [JsonProperty("modified")]
        public string? Modified { get; set; }
        [JsonIgnore]
        public string? ModifiedDate => DateTime.TryParse(Modified, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime) ? dateTime.ToShortDateString() : null;
        [JsonProperty("thumbnail")]
        public ItemThumbnailDto? Thumbnail { get; set; }
        
    }
}