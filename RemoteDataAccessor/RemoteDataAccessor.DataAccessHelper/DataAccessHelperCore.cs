using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.DataAccessHelper
{
    public class DataAccessHelperCore : IDataAccessHelper
    {
        private readonly IDataAccessHelperSettings _dataAccessHelperSettings;

        public DataAccessHelperCore(IDataAccessHelperSettings dataAccessHelperSettings)
        {
            _dataAccessHelperSettings = dataAccessHelperSettings;
        }
    }
}
