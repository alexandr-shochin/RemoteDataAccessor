using RemoteDataAccessor.Common.Interfaces.s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.APIProvider
{
    public class APIProviderCore : IAPIProvider
    {
        private readonly IAPIProviderSettings _apiProviderSettings;

        public APIProviderCore(IAPIProviderSettings apiProviderSettings)
        {
            _apiProviderSettings = apiProviderSettings;
        }
    }
}
