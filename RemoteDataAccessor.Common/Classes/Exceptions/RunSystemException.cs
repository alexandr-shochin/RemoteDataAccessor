using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Classes.Exceptions
{
    public class RunSystemException : Exception
    {
        public RunSystemException()
        {
        }

        public RunSystemException(string message)
            : base(message)
        {
        }

        public RunSystemException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
