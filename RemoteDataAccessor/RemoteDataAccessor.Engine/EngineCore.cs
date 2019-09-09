using RemoteDataAccessor.Common.Interfaces.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;

using NLog;
using RemoteDataAccessor.Common.Interfaces.Helpers;

namespace RemoteDataAccessor.Engine
{
    public class EngineCore : IEngine
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IComponent[] _componets;

        private IEngineSettings _engineSettings;
        private IDataAccessHelperSettings _dataAccessHelperSettings;
        private IDataAccessHelper _dataAccessHelper;

        public EngineCore(IComponent[] componets)
        {
            _componets = componets;
        }

        public void Initialize()
        {
            foreach (var component in _componets)
            {
                switch (component)
                {
                    case IEngineSettings engineSettings:
                        RegisterEngineSettings(engineSettings);
                        break;
                    case IDataAccessHelperSettings dataAccessHelperSettings:
                        RegisterDataAccessHelperSettings(dataAccessHelperSettings);
                        break;
                    case IDataAccessHelper dataAccessHelper:
                        RegisterDataAccessHelper(dataAccessHelper);
                        break;
                    default:
                        Logger.Fatal("Unknown component type");
                        throw new Exception("Unknown component type");
                }
            }
        }

        public void Validate()
        {
            // TODO
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1 * 1000);
            }
        }

        #region Register components

        private void RegisterEngineSettings(IEngineSettings engineSettings)
        {
            _engineSettings = engineSettings; // TODO
        }

        private void RegisterDataAccessHelperSettings(IDataAccessHelperSettings dataAccessHelperSettings)
        {
            _dataAccessHelperSettings = dataAccessHelperSettings; // TODO
        }

        private void RegisterDataAccessHelper(IDataAccessHelper dataAccessHelper)
        {
            _dataAccessHelper = dataAccessHelper; // TODO
        }

        #endregion
    }
}
