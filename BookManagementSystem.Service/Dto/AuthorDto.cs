using BookManagementSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManagementSystem.Service.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public int BookId { get; set; } 

    }
}
