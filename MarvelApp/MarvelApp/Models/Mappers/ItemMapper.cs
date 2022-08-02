using System;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.I18N;

namespace MarvelApp.Models.Mappers
{
    public static class ItemMapper
    {
        public static ItemModel MapFromDtoToModel(ItemDto dto)
        {
            return new ItemModel()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description ?? AppTexts.EmptyDescription,
                ModifiedDate = dto.ModifiedDate ?? AppTexts.EmptyDate,
                ImagePath = dto.Thumbnail?.Image
            };
        }
    }
}