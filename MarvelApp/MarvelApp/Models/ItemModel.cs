using System;

namespace MarvelApp.Models
{
    public class ItemModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ImagePath { get; set; }
    }
}