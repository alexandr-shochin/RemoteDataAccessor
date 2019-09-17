using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Interfaces.WcfContracts
{
    [ServiceContract]
    public interface IApiProviderContract : IDisposable
    {
        [OperationContract]
        List<string> GetData();

        [OperationContract]
        int GetNumOfGetDataRun();
    }
}
