using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.CustomException
{
    public class BookException : Exception
    {
        public BookException(string masege)
         : base(String.Format(masege))
        {
        }
    }
}
