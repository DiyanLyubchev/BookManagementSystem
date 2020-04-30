using BookManagementSystem.Data.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookManagementSystem.Data.Model
{
    [Table("BookLending")]
    public class BookLending : BaseEntities
    {
        public DateTime TakeDate { get; set; }

        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("UserAccount")]
        public int? UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
