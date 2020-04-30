using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.Dto
{
    public class UserAccountDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<BookLendingDto> BookLendings { get; set; }
    }
}
