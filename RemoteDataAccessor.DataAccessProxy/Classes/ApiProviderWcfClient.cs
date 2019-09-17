using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;
using RemoteDataAccessor.DataAccessProxy.Interfaces;

namespace RemoteDataAccessor.DataAccessProxy.Classes
{
    public class ApiProviderWcfClient : WcfClientBase<IApiProviderContract>, IApiProviderWcfClient
    {
        public ApiProviderWcfClient(IDataAccessProxySettings dataAccessProxySettings) : 
            base(new ChannelManager<IApiProviderContract>(dataAccessProxySettings),
            new ReconnectChannelManager<IApiProviderContract>(dataAccessProxySettings))
        {
        }

        public List<string> GetData()
        {
            return ExecuteMethod(x => x.GetData());
        }

        public int GetNumOfGetDataRun()
        {
            return ExecuteMethod(x => x.GetNumOfGetDataRun());
        }

        public void Dispose()
        {

        }
    }
}
