using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

using RemoteDataAccessor.Common.Classes.WcfServices;
using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;

namespace RemoteDataAccessor.APIProvider
{
    public class APIProviderCore : IAPIProvider
    {
        private ServiceHost _host = null;

        private const long MaxReceivedMessageSize = 67108864;

        private readonly IAPIProviderSettings _apiProviderSettings;

        public APIProviderCore(IAPIProviderSettings apiProviderSettings)
        {
            _apiProviderSettings = apiProviderSettings;

            Uri uri = new Uri($"net.tcp://{Dns.GetHostName()}:{13000}/{typeof(IApiProviderContract)}");

            _host = new ServiceHost(typeof(ApiProviderService), uri);
            _host.OpenTimeout = TimeSpan.MaxValue;
            //_host.Faulted += _host_Faulted;
            //_host.UnknownMessageReceived += _host_UnknownMessageReceived;

            NetTcpBinding netTcpBinding = new NetTcpBinding()
            {
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                Security = new NetTcpSecurity { Mode = SecurityMode.None }
            };

            _host.AddServiceEndpoint(typeof(IApiProviderContract), netTcpBinding, uri);
            _host.Open();
        }
    }
}
