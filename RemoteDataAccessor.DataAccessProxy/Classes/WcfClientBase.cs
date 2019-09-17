using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;
using RemoteDataAccessor.DataAccessProxy.Interfaces;

namespace RemoteDataAccessor.DataAccessProxy.Classes
{
    public class WcfClientBase<TRequestContract>
    {
        private IChannelManager<TRequestContract> _channelManager;
        private readonly IReconnectChannelManager<TRequestContract> _reconnectManager;

        protected WcfClientBase(IChannelManager<TRequestContract> channelManager, IReconnectChannelManager<TRequestContract> reconnectManager)
        {
            _channelManager = channelManager;
            _reconnectManager = reconnectManager;
        }

        protected Type ExecuteMethod<Type>(Func<TRequestContract, Type> method)
        {
            try
            {
                return method(_channelManager.RequestContract);
            }
            catch (FaultException ex)
            {
                _reconnectManager.Reconnect(ref _channelManager);
                throw ex;
            }
            catch (TimeoutException ex)
            {
                _reconnectManager.Reconnect(ref _channelManager);
                throw ex;
            }
            catch (CommunicationException ex)
            {
                _reconnectManager.Reconnect(ref _channelManager);
                throw ex;
            }
            catch (Exception ex)
            {
                _reconnectManager.Reconnect(ref _channelManager);
                throw ex;
            }
        }
    }
}
