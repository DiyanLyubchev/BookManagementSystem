using AutoMapper;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Models;
using BookManagementSystem.Service.Dto;

namespace BookManagementSystem.AutoMapperProfiles
{
    public class BookLendingProfiles : Profile
    {
        public BookLendingProfiles()
        {
            CreateMap<BookLending, BookLendingDto>().ReverseMap();
            CreateMap<BookLendingViewModel, BookLendingDto>().ReverseMap();
        }
    }
}
