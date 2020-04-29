using BookManagementSystem.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public int AuthorId { get; set; }

        public  ICollection<AuthorDto> Authors { get; set; }
    }
}
