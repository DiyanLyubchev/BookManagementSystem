using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Data.Extension
{
    public static class SeedBookLending
    {
        public static void SeedBookLend(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLending>().HasData(CreateLend());

        }

        private static BookLending[] CreateLend()
        {
            return new BookLending[]
            {
                new BookLending
                {
                     Id= 1,
                     BookId = 1,
                     UserAccountId = 2,
                     TakeDate = DateTime.Now
                },
                new BookLending
                {
                     Id= 2,
                     BookId = 2,
                     UserAccountId = 3,
                     TakeDate = new DateTime(2020, 1, 12)
                },
                new BookLending
                {
                     Id= 3,
                     BookId = 3,
                     UserAccountId = 1,
                     TakeDate = new DateTime(2020, 3, 21)
                },
            };

        }
    }
}
