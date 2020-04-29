using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.CustomException
{
    public class AuthorException : Exception
    {
        public AuthorException(string masege)
         : base(String.Format(masege))
        {
        }
    }
}
