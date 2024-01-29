using AutoMapper;
using BookStoreApp.API.DTOs.Author;
using BookStoreApp.API.DTOs.Book;
using BookStoreApp.API.DTOs.User;
using BookStoreApp.API.Models;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
           
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => 
                    $"{map.Author.FirstName} {map.Author.LastName}"
                    ))
                .ReverseMap();
            CreateMap<Book, BookDetailsDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map =>
                    $"{map.Author.FirstName} {map.Author.LastName}"
                    ))
                .ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();

        }
    }
}
