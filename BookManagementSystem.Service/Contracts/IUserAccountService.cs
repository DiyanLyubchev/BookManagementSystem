using BookManagementSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Contracts
{
    public interface IUserAccountService
    {
        Task AddUserAsync(UserAccountDto dto);
        Task<IEnumerable<UserAccountDto>> GetAllUsersAsync();
    }
}