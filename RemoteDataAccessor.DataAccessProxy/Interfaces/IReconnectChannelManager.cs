using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.DataAccessProxy.Interfaces
{
    public interface IReconnectChannelManager<TContract>
    {
        void Reconnect(ref IChannelManager<TContract> channelManager);
    }
}
