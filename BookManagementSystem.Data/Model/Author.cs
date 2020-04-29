using BookManagementSystem.Data.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Data.Model
{
    [Table("Author")]
    public class Author : BaseEntities
    {

        public string AuthorName { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Book")]
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
