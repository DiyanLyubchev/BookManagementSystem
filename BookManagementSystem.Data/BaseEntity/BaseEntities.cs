using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookManagementSystem.Data.BaseEntity
{
    public class BaseEntities
    {
        [Key]
        public int Id { get; set; }
    }
}
