using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.Common.Classes.Settings
{
    public class DataAccessProxySettings : IDataAccessProxySettings
    {
        public IpEndPointsSource<IPEndPoint> IpEndPoints { get; set; }
    }
}
