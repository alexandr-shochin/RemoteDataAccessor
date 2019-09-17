using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.DataAccessProxy.Interfaces;

namespace RemoteDataAccessor.DataAccessProxy.Classes
{
    public class ReconnectChannelManager<TContract> : IReconnectChannelManager<TContract>
    {
        private readonly LogTools _logTools = new LogTools();

        private readonly IDataAccessProxySettings _dataAccessProxySettings;

        public ReconnectChannelManager(IDataAccessProxySettings dataAccessProxySettings)
        {
            _dataAccessProxySettings = dataAccessProxySettings;
        }

        public void Reconnect(ref IChannelManager<TContract> channelManager)
        {
            while (true)
            {
                bool result;
                IChannelManager<TContract> newChannelManager = null;

                try
                {
                    channelManager.Close();

                    newChannelManager = new ChannelManager<TContract>(_dataAccessProxySettings);

                    channelManager = newChannelManager;

                    result = true;
                }
                catch (Exception ex)
                {
                    newChannelManager?.Close();

                    result = false;
                }

                if (result)
                    break;
            }
        }
    }
}
