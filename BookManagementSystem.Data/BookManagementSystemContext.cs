using BookManagementSystem.Data.Extension;
using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookManagementSystem.Data
{
    public class BookManagementSystemContext : DbContext
    {
        public BookManagementSystemContext()
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<BookLending> BookLendings { get; set; }

        public BookManagementSystemContext(DbContextOptions<BookManagementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurationsAuthor();
            builder.ConfigurationsBookLending();
            builder.ConfigurationsBook();
            builder.ConfigurationsUser();
            builder.SeedAutor();
            builder.SeedBook();
            builder.SeedUser();
            builder.SeedBookLend();
            base.OnModelCreating(builder);
        }
    }
}
