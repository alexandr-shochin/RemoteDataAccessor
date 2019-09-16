using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;
using RemoteDataAccessor.DataAccessProxy.Classes;

namespace RemoteDataAccessor.DataAccessProxy
{
    public class DataAccessProxyCore : IDataAccessProxy, IApiProviderContract
    {
        private readonly LogTools _logTools = new LogTools();

        private readonly IDataAccessProxySettings _dataAccessProxySettings;

        private readonly ApiProviderWcfClient _apiProviderWcfClient;

        public DataAccessProxyCore(IDataAccessProxySettings dataAccessProxySettings)
        {
            _dataAccessProxySettings = dataAccessProxySettings;

            _apiProviderWcfClient = new ApiProviderWcfClient(dataAccessProxySettings);
        }

        public List<string> GetData()
        {
            try
            {
                return _apiProviderWcfClient.GetData();
            }
            catch (Exception ex)
            {
                _logTools.WriteLogToConsole<Error>(ex);
                _logTools.WriteLogToFile<Error>(ex);

                return new List<string>();
            }
        }

        public int GetNumOfGetDataRun()
        {
            try
            {
                return _apiProviderWcfClient.GetNumOfGetDataRun();
            }
            catch (Exception ex)
            {
                _logTools.WriteLogToConsole<Error>(ex);
                _logTools.WriteLogToFile<Error>(ex);

                return -1;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
