using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.DataAccessProxy.Interfaces
{
    public interface IChannelManager<out TRequestContract>
    {
        TRequestContract RequestContract { get; }

        void Open();
        void Close();
    }
}
