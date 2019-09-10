using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Classes.Exceptions
{
    public class UnknownComponentException : Exception
    {
        public UnknownComponentException()
        {
        }

        public UnknownComponentException(string message)
            : base(message)
        {
        }

        public UnknownComponentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
