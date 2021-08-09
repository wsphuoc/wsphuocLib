using System;
using System.Collections.Generic;
using System.Text;

namespace wsphuoc.Exceptions
{
    public class wsphuocException : Exception
    {
        public wsphuocException() { }
        public wsphuocException(string message)
            : base(message)
        {

        }
        public wsphuocException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
