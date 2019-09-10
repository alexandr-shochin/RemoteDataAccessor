using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.DataAccessHelperProxy
{
    public class DataAccessHelperProxyCore : IDataAccessHelperProxy
    {
        private readonly IDataAccessHelperProxySettings _dataAccessHelperSettings;

        public DataAccessHelperProxyCore(IDataAccessHelperProxySettings dataAccessHelperSettings)
        {
            _dataAccessHelperSettings = dataAccessHelperSettings;
        }
    }
}
