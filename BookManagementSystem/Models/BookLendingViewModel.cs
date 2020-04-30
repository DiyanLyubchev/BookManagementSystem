using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Models
{
    public class BookLendingViewModel
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public int BookId { get; set; }
    }
}
