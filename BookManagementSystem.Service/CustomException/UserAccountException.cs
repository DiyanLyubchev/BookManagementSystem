using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem.Service.CustomException
{
    public class UserAccountException : Exception
    {
        public UserAccountException(string masege)
        : base(String.Format(masege))
        {
        }
    }
}
