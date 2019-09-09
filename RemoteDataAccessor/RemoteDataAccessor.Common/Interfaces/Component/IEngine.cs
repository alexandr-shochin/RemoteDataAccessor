using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.Common.Interfaces.Component
{
    public interface IEngine
    {
        void Initialize();
        void Validate();
        void Run();
    }
}
