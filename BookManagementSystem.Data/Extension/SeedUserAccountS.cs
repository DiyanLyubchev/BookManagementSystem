using BookManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Data.Extension
{
    public static class SeedUserAccountS
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(CreateUser());

        }

        private static UserAccount[] CreateUser()
        {
            return new UserAccount[]
            {
                new UserAccount
                {
                     Id= 1,
                     FirstName="Dimitur",
                     LastName = "Sokolov"
                },
                new UserAccount
                {
                     Id= 2,
                     FirstName = "Kaloqn",
                     LastName = "Ivanov"
                },
                new UserAccount
                {
                     Id= 3,
                     FirstName = "Emiliqn",
                     LastName = "Nikolov"
                },
            };

        }
    }
}
