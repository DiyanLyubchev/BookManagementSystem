using AutoMapper;
using BookManagementSystem.Data;
using BookManagementSystem.Data.Model;
using BookManagementSystem.Service.Contracts;
using BookManagementSystem.Service.CustomException;
using BookManagementSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Service
{
    public class BookService : IBookService
    {
        private readonly BookManagementSystemContext context;
        private readonly IMapper mapper;

        public BookService(BookManagementSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddBookAsync(BookDto dto)
        {
            if (dto == null)
            {
                throw new BookException("Data from dto cannot be null!");
            }

            var currentAuthor = await this.context.Authors
                .Include(book => book.Book)
                .FirstOrDefaultAsync(authorId => authorId.Id == dto.AuthorId);
            if (currentAuthor == null)
            {
                throw new BookException($"Author with the following ID: {dto.AuthorId} does not exist!");
            }

            var newBook = this.mapper.Map<Book>(dto);
            newBook.Authors = new List<Author> { currentAuthor };
            var id = await this.GetNextValueAsync();
            newBook.Id = id;

            await this.context.Books.AddAsync(newBook);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select Book_seq.NEXTVAL as NEXTVAL from dual";
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var listBook = await this.context.Books
                .Include(author => author.Authors)
                .Where(existBook => existBook.IsDeleted == false)
                .ToListAsync();

            if (listBook == null)
            {
                throw new BookException("There no hava any books!");
            }

            var resultAllBook = this.mapper.Map<List<BookDto>>(listBook);

            return resultAllBook;
        }

        public async Task<BookDto> FindBookByIdAsync(int id)
        {
            var book = await this.context.Books
                .Include(author => author.Authors)
                .FirstOrDefaultAsync(existBook => existBook.IsDeleted == false && existBook.Id == id);


            if (book == null)
            {
                throw new BookException($"Book with the following ID: {id} does not exist!");
            }

            var resultBook = this.mapper.Map<BookDto>(book);

            return resultBook;
        }

        public async Task<string> RemoveBookAsync(int id)
        {
            var currentBook = await this.context.Books
                .SingleOrDefaultAsync(bookId => bookId.Id == id);

            if (currentBook == null)
            {
                throw new BookException($"Book with the following ID: {id} does not exist!");
            }

            currentBook.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return $"Book with the following id: {id} was deleted";
        }

        public async Task<BookDto> UpdateBookAsync(int id, BookDto dto)
        {
            var currentBook = await this.context.Books
                .Include(author => author.Authors)
                .SingleOrDefaultAsync(bookId => bookId.Id == id && bookId.IsDeleted == false);

            if (currentBook == null)
            {
                throw new BookException($"Book with the following ID: {id} does not exist!");
            }

            if (dto == null)
            {
                throw new BookException($"Book data cannot be null!");
            }
            var currentAuthor = await context.Authors
                .SingleOrDefaultAsync(authorId => authorId.Id == dto.AuthorId && authorId.IsDeleted == false);


            if (currentAuthor != null)
            {
                var updatedAuthor = dto.Authors.SingleOrDefault(authorId => authorId.Id == currentAuthor.Id);
                await this.UpdateAuthor(currentAuthor.Id, updatedAuthor);
            }

            currentBook.BookTitle = dto.BookTitle;
            currentBook.DateCreated = dto.DateCreated;

            await this.context.SaveChangesAsync();

            return this.mapper.Map<BookDto>(currentBook);

        }

        private async Task UpdateAuthor(int authorId, AuthorDto author)
        {
            var newAuthor = await this.context.Authors
                .SingleOrDefaultAsync(id => id.Id == authorId);


            newAuthor.AuthorName = author.AuthorName;
            newAuthor.BookId = author.BookId;
            await this.context.SaveChangesAsync();
        }


    }
}




