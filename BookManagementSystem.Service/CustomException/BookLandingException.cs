using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.CustomException
{
    public class BookLandingException : Exception
    {
        public BookLandingException(string masege)
        : base(String.Format(masege))
        {
        }
    }
}
