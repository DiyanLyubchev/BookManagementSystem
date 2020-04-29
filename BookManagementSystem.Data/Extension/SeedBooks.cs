using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Data.Extension
{
    public static class SeedBooks
    {
        public static void SeedBook(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(CreateBook());

        }

        private static Book[] CreateBook()
        {
            return new Book[]
            {
                new Book
                {
                     Id= 1,
                     BookTitle="Pod Igoto",
                     DateCreated = new DateTime(2014, 4, 21)
                },
                new Book
                {
                     Id= 2,
                     BookTitle="Poeziq",
                     DateCreated = new DateTime(2020, 2, 21)
                },
                new Book
                {
                     Id= 3,
                     BookTitle="V polite na Vitosha",
                     DateCreated = new DateTime(2018, 6, 21)
                },
            };

        }
    }
}
