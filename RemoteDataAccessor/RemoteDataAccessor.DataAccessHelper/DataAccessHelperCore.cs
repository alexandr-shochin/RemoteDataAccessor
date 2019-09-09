using RemoteDataAccessor.Common.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RemoteDataAccessor.Common.Classes.Settings;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.DataAccessHelper
{
    public class DataAccessHelperCore : IDataAccessHelper
    {
        private readonly IDataAccessHelperSettings _dataAccessHelperSettings;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public DataAccessHelperCore(IDataAccessHelperSettings dataAccessHelperSettings)
        {
            _dataAccessHelperSettings = dataAccessHelperSettings;
        }
    }
}
