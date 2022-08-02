using System.Collections.Generic;
using MarvelApp.DomainServices.DTOs;
using MarvelApp.Models;
using Prism.Navigation;

namespace MarvelApp.Tests
{
    public static class MockHelper
    {
        public static ItemModel GetItem()
        {
            return new ItemModel()
            {
                Id = 123,
                Title = "Title",
                Description = "Description",
                ImagePath = "ImagePath",
                ModifiedDate = "ModifiedDate"
            };
        }
        
        public static List<ItemModel> GetItems()
        {
            return new List<ItemModel>()
            {
                new ItemModel()
                {
                    Id = 1,
                    Title = "Title",
                    Description = "Description",
                    ImagePath = "ImagePath",
                    ModifiedDate = "ModifiedDate"
                },
                new ItemModel()
                {
                    Id = 2,
                    Title = "Title1",
                    Description = "Description1",
                    ImagePath = "ImagePath1",
                    ModifiedDate = "ModifiedDate1"
                },
                new ItemModel()
                {
                    Id = 3,
                    Title = "Title2",
                    Description = "Description2",
                    ImagePath = "ImagePath2",
                    ModifiedDate = "ModifiedDate2"
                },
                new ItemModel()
                {
                    Id = 4,
                    Title = "Title3",
                    Description = "Description3",
                    ImagePath = "ImagePath3",
                    ModifiedDate = "ModifiedDate3"
                }
            };
        }

        public static string GetSearchText()
        {
            return "Ant-";
        }
        
        public static NavigationParameters GetNavigationParameters()
        {
            return new NavigationParameters()
            {
                {NavigationConstants.ItemParameter, GetItem()}
            };
        }
        
        public static ItemResponseDto GetItemResponseDto()
        {
            return new ItemResponseDto()
            {
                Data = new ItemDataDto()
                {
                    Count = 4,
                    Results = new[]
                    {
                        new ItemDto()
                        {
                            Id = 3,
                            Title = "Title3",
                            Description = "Description3",
                            Modified = "Modified",
                            Thumbnail = new ItemThumbnailDto()
                            {
                                Path = "Path",
                                Extension = "Extension"
                            }
                        }
                    }
                }
            };
        }

    }
}