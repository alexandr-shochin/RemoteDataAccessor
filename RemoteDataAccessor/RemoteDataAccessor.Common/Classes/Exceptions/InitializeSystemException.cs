using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Classes.Exceptions
{
    public class InitializeSystemException : Exception
    {
        public InitializeSystemException()
        {
        }

        public InitializeSystemException(string message)
            : base(message)
        {
        }

        public InitializeSystemException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
