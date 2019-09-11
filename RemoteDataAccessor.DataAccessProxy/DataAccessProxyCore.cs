using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.DataAccessProxy
{
    public class DataAccessProxyCore : IDataAccessProxy
    {
        private readonly IDataAccessProxySettings _dataAccessProxySettings;

        public DataAccessProxyCore(IDataAccessProxySettings dataAccessProxySettings)
        {
            _dataAccessProxySettings = dataAccessProxySettings;
        }
    }
}
