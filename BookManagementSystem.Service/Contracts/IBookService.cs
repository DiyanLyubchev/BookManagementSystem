using BookManagementSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Contracts
{
    public interface IBookService
    {
        Task AddBookAsync(BookDto dto);

        Task<IEnumerable<BookDto>> GetAllBooksAsync();

        Task<BookDto> FindBookByIdAsync(int id);

        Task<string> RemoveBookAsync(int id);

        Task<BookDto> UpdateBookAsync(int id, BookDto dto);
    }
}