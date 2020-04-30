using AutoMapper;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Models;
using BookManagementSystem.Service.Dto;

namespace BookManagementSystem.AutoMapperProfiles
{
    public class UserAccountProfiles : Profile
    {
        public UserAccountProfiles()
        {
            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
            CreateMap<UserAccountViewModel, UserAccountDto>().ReverseMap();
        }
    }
}
