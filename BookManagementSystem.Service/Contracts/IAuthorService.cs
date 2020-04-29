using BookManagementSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync();

        Task<AuthorDto> GetAuthorByIdAsync(int id);

        Task<string> RemoveAuthorAsync(int id);

        Task AddAuthorAsync(AuthorDto dto);

        Task<AuthorDto> UpdateAuthorAsync(int id, AuthorDto dto);
    }
}