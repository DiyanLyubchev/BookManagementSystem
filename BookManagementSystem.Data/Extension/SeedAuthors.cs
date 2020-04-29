using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Data.Extension
{
    public static class SeedAuthors
    {
        public static void SeedAutor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(CreateAuthor());

        }

        private static Author[] CreateAuthor()
        {
            return new Author[]
            {
                new Author
                {
                     Id= 1,
                     AuthorName="Ivan Vazov"
                },
                new Author
                {
                     Id= 2,
                     AuthorName="Peio Qvorov"
                },
                new Author
                {
                     Id= 3,
                     AuthorName="Dimcho Debelqnov"
                },
            };

        }
    }
}
