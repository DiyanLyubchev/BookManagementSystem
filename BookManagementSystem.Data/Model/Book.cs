using BookManagementSystem.Data.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Data.Model
{
    [Table("Book")]
    public class Book : BaseEntities
    {
        public string BookTitle { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<BookLending>  BookLendings { get; set; }
    }
}
