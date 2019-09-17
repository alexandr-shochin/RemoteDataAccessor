using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.DataAccessProxy.Interfaces;

namespace RemoteDataAccessor.DataAccessProxy.Classes
{
    public class ChannelManager<TRequestContract> : IChannelManager<TRequestContract>
    {
        private ChannelFactory<TRequestContract> _requestChannel;

        public ChannelManager(IDataAccessProxySettings dataAccessProxySettings)
        {
            IPEndPoint ipEndPoint = dataAccessProxySettings.IpEndPoints.GetNextItem();
            RequestContract = CreateChannel(ipEndPoint.Address, ipEndPoint.Port);
        }

        private TRequestContract CreateChannel(IPAddress address, int port)
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.None);
            _requestChannel = new ChannelFactory<TRequestContract>(netTcpBinding);

            _requestChannel.Opened += ChannelOnOpened;
            _requestChannel.Closed += ChannelOnClosed;
            _requestChannel.Faulted += ChannelOnFaulted;

            EndpointAddress endPoint = new EndpointAddress(new Uri($"net.tcp://{address}:{port}/{typeof(TRequestContract)}"));

            return _requestChannel.CreateChannel(endPoint);
        }

        private void CloseChannel()
        {
            try
            {
                if (_requestChannel.State == CommunicationState.Opened)
                    _requestChannel.Close();
                else
                    _requestChannel.Abort();

                _requestChannel.Opened -= ChannelOnOpened;
                _requestChannel.Closed -= ChannelOnClosed;
                _requestChannel.Faulted -= ChannelOnFaulted;
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        private void ChannelOnOpened(object sender, EventArgs e)
        {
            // TODO
        }

        private void ChannelOnClosed(object sender, EventArgs e)
        {
            // TODO
        }

        private void ChannelOnFaulted(object sender, EventArgs e)
        {
            // TODO
        }

        public TRequestContract RequestContract { get; }

        public void Open()
        {
            _requestChannel.Open();
        }

        public void Close()
        {
            CloseChannel();
        }
    }
}
