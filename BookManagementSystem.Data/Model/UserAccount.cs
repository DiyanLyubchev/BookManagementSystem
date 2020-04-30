using BookManagementSystem.Data.BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Data.Model
{
    [Table("UserAccount")]
    public class UserAccount : BaseEntities
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<BookLending> BookLendings { get; set; }
    }
}
