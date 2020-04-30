using AutoMapper;
using BookManagementSystem.Data;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Service.Contracts;
using BookManagementSystem.Service.CustomException;
using BookManagementSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Service
{
    public class UserAccountService : IUserAccountService
    {
        private readonly BookManagementSystemContext context;
        private readonly IMapper mapper;

        public UserAccountService(BookManagementSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddUserAsync(UserAccountDto dto)
        {
            if (dto == null)
            {
                throw new AuthorException("User data cannot be null!");
            }

            var newUser = this.mapper.Map<UserAccount>(dto);

            var id = await GetNextValueAsync();
            newUser.Id = id;

            await this.context.UserAccounts.AddAsync(newUser);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select UserAccount_seq.NEXTVAL as NEXTVAL from dual";
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }

        public async Task<IEnumerable<UserAccountDto>> GetAllUsersAsync()
        {
            var users = await this.context.UserAccounts
                .Include(bland => bland.BookLendings)
                .ThenInclude(book => book.Book)
                .ToListAsync();

            if (users == null)
            {
                throw new UserAccountException("There is no have any users!");
            }

            var returnListAutors = this.mapper.Map<List<UserAccountDto>>(users);

            return returnListAutors;
        }
    }
}
