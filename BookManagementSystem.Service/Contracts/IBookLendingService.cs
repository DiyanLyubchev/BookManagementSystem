using BookManagementSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Contracts
{
    public interface IBookLendingService
    {
        Task AddBookLandingAsync(BookLendingDto dto);
        Task<IEnumerable<BookLendingDto>> GetAllBookLandingsAsync();
    }
}