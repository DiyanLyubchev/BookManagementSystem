using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.Dto
{
    public class BookLendingDto
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public int BookId { get; set; }
    }
}
