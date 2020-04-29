using BookManagementSystem.Data.Model;
using System;
using System.Collections.Generic;

namespace BookManagementSystem.Service.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public int AuthorId { get; set; }

        public ICollection<AuthorDto> Authors { get; set; }
    }
}
