using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;

namespace RemoteDataAccessor.Common.Classes.WcfServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ApiProviderService : IApiProviderContract
    {
        private int _getDataRun;

        public List<string> GetData()
        {
            _getDataRun++;

            Random random = new Random();

            byte[] bytes = new byte[random.Next(1, 10)];
            random.NextBytes(bytes);

            return bytes.Select(x => x.ToString()).ToList();
        }

        public int GetNumOfGetDataRun()
        {
            return _getDataRun;
        }

        #region Implementation of IDisposable

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose all objects
                _getDataRun = 0;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Ensure that the destructor is not called
        }

        #endregion
    }
}
