using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Data.Extension
{
    public static class EntityConfigurations
    {
        public static ModelBuilder ConfigurationsAuthor(this ModelBuilder builder)
        {
            return builder.Entity<Author>(entity =>
            {
               entity.ToTable("AUTHOR");

                entity.HasKey(key => key.Id);

                entity.Property(id => id.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(10)");

                entity.Property(authorName => authorName.AuthorName)
                 .IsRequired()
                 .HasColumnName("AUTHORNAME")
                 .HasColumnType("VARCHAR2(40)");

               entity.HasOne(book => book.Book)
               .WithMany(author => author.Authors)
               .HasForeignKey(foreignKey => foreignKey.BookId);

            });
        }

        public static ModelBuilder ConfigurationsBook(this ModelBuilder builder)
        {
            return builder.Entity<Book>(entity =>
             {
                 entity.ToTable("BOOK");

                 entity.HasKey(key => key.Id);

                 entity.Property(id => id.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(10)");

                 entity.Property(bookTitle => bookTitle.BookTitle)
                   .IsRequired()
                   .HasColumnName("BOOKTITLE")
                   .HasColumnType("VARCHAR2(50)");

                 entity.Property(year => year.DateCreated)
                 .HasColumnName("DATECREATED")
                 .HasColumnType("DATE");

                 entity.HasMany(author => author.Authors)
                 .WithOne(book => book.Book);
             });
        }
        public static ModelBuilder ConfigurationsUser(this ModelBuilder builder)
        {
            return builder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("USERACCOUNT");

                entity.HasKey(key => key.Id);

                entity.Property(id => id.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(10)");

                entity.Property(firstName => firstName.FirstName)
                 .IsRequired()
                 .HasColumnName("FIRSTNAME")
                 .HasColumnType("VARCHAR2(40)");

                entity.Property(lastName => lastName.LastName)
                   .IsRequired()
                   .HasColumnName("LASTNAME")
                   .HasColumnType("VARCHAR2(40)");

                entity.HasMany(book => book.BookLendings)
                .WithOne(author => author.UserAccount);

            });
        }

        public static ModelBuilder ConfigurationsBookLending(this ModelBuilder builder)
        {
            return builder.Entity<BookLending>(entity =>
            {
                entity.ToTable("BOOKLENDING");

                entity.HasKey(key => key.Id);

                entity.Property(id => id.Id)
                   .HasColumnName("ID")
                   .HasColumnType("NUMBER(10)");

                entity.Property(year => year.TakeDate)
                .HasColumnName("TAKEDATE")
                .HasColumnType("DATE");

                entity.HasOne(user => user.UserAccount)
                .WithMany(blanding => blanding.BookLendings)
                .HasForeignKey(userId => userId.UserAccountId);

                entity.HasOne(book => book.Book)
                .WithMany(landing => landing.BookLendings)
                .HasForeignKey(bookId => bookId.BookId);
            });
        }

    }
}
