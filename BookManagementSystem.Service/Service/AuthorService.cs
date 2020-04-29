using AutoMapper;
using BookManagementSystem.Data;
using BookManagementSystem.Service.Contracts;
using BookManagementSystem.Service.CustomException;
using BookManagementSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BookManagementSystem.Data.Model;

namespace BookManagementSystem.Service.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly BookManagementSystemContext context;
        private readonly IMapper mapper;

        public AuthorService(BookManagementSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync()
        {
            var authors = await this.context.Authors
                .Where(existAutor => existAutor.IsDeleted == false)
                .ToListAsync();

            if (authors == null)
            {
                throw new AuthorException("There is no have any authors!");
            }

            var returnListAutors = this.mapper.Map<List<AuthorDto>>(authors);

            return returnListAutors;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var currentAuthor = await this.context.Authors
                .Where(existAutor => existAutor.IsDeleted == false && existAutor.Id == id)
                .SingleOrDefaultAsync();

            if (currentAuthor == null)
            {
                throw new AuthorException($"Author with the following id: {id} does not exist!");
            }

            return this.mapper.Map<AuthorDto>(currentAuthor);
        }

        public async Task<string> RemoveAuthorAsync(int id)
        {
            var currentAuthor = await this.context.Authors
                .Include(book => book.Book)
                .SingleOrDefaultAsync(authorId => authorId.Id == id);

            if (currentAuthor == null)
            {
                throw new AuthorException($"Author with the following id: {id} does not exist!");
            }
            currentAuthor.IsDeleted = true;
            currentAuthor.BookId = null;
            await this.context.SaveChangesAsync();

            return $"Author with the following id: {id} was deleted";
        }

        public async Task AddAuthorAsync(AuthorDto dto)
        {
            if (dto == null)
            {
                throw new AuthorException("Author data cannot be null!");
            }

            var currentBook =await this.context.Books
                .SingleOrDefaultAsync(bookId => bookId.Id == dto.BookId);

            if (currentBook == null )
            {
                throw new AuthorException($"Book with the following ID: {dto.BookId} does not exist!");
            }

            var newAuthor = this.mapper.Map<Author>(dto);
            newAuthor.Book = currentBook;
            var id =await GetNextValueAsync();
            newAuthor.Id = id;

            await this.context.Authors.AddAsync(newAuthor);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select Author_seq.NEXTVAL as NEXTVAL from dual";
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }


        public async Task<AuthorDto> UpdateAuthorAsync(int id, AuthorDto dto)
        {
            var currentAuthor = await this.context.Authors
                .Include(book => book.Book)
                .SingleOrDefaultAsync(authorId => authorId.Id == id && authorId.IsDeleted == false);
            if (currentAuthor == null)
            {
                throw new AuthorException($"Author with the following id: {id} does not exist!");
            }

            var existBook = await this.context.Books
                .SingleOrDefaultAsync(bookId => bookId.Id == dto.BookId && bookId.IsDeleted == false);

            if (existBook == null)
            {
                throw new AuthorException($"Book with the following id: {dto.BookId} does not exist!");
            }

            currentAuthor.AuthorName = dto.AuthorName;
            currentAuthor.BookId = dto.BookId;
            currentAuthor.Book = existBook;

            await this.context.SaveChangesAsync();

            return this.mapper.Map<AuthorDto>(currentAuthor);
        }
    }
}
