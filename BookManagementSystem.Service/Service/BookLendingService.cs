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
    public class BookLendingService : IBookLendingService
    {
        private readonly BookManagementSystemContext context;
        private readonly IMapper mapper;

        public BookLendingService(BookManagementSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddBookLandingAsync(BookLendingDto dto)
        {
            if (dto == null)
            {
                throw new BookLandingException("User data cannot be null!");
            }
            var currentUser =await this.context.UserAccounts
                .SingleOrDefaultAsync(userId => userId.Id == dto.UserAccountId);

            if (currentUser == null)
            {
                throw new BookLandingException($"User with the following id: { dto.UserAccountId} does not exist!");
            }

            var currentBook = await this.context.Books
                .SingleOrDefaultAsync(bookId => bookId.Id == dto.BookId && bookId.IsDeleted == false);

            if (currentBook == null)
            {
                throw new BookLandingException($"Book with the following id: { dto.BookId} does not exist!");
            }

            var lendBook = this.mapper.Map<BookLending>(dto);

            var id = await GetNextValueAsync();
            lendBook.Id = id;
            lendBook.UserAccount = currentUser;

            await this.context.BookLendings.AddAsync(lendBook);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select BookLanding_seq.NEXTVAL as NEXTVAL from dual";
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }

        public async Task<IEnumerable<BookLendingDto>> GetAllBookLandingsAsync()
        {
            var allBookLanding = await this.context.BookLendings
                .Include(book => book.Book)
                .Include(user => user.UserAccount)
                .ToListAsync();

            var returnBookLanding = this.mapper.Map<List<BookLendingDto>>(allBookLanding);

            return returnBookLanding;
        }
    }
}
