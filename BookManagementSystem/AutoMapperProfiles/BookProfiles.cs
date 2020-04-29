using AutoMapper;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Models;
using BookManagementSystem.Service.Dto;

namespace BookManagementSystem.AutoMapperProfiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookViewModel, BookDto>().ReverseMap();
        }
    }
}
