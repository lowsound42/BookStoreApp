using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();

        }
    }
}
