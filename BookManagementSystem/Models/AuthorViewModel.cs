using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public int BookId { get; set; }
    }
}
