using AutoMapper;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Models;
using BookManagementSystem.Service.Dto;

namespace BookManagementSystem.AutoMapperProfiles
{
    public class AuthorProfiles : Profile
    {
        public AuthorProfiles()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<AuthorDto, AuthorViewModel>().ReverseMap();
        }
    }
}
