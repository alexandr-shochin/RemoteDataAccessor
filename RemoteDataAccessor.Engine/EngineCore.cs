using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Classes.Exceptions;
using RemoteDataAccessor.Common.Interfaces.Component;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Engine.Properties;

namespace RemoteDataAccessor.Engine
{
    public class EngineCore : IEngine
    {
        private readonly IComponent[] _componets;

        private IEngineSettings _engineSettings;
        private IDataAccessHelperProxySettings _dataAccessHelperProxySettings;
        private IDataAccessHelperProxy _dataAccessHelperProxy;

        public EngineCore(IComponent[] componets)
        {
            _componets = componets;
        }

        public void Initialize()
        {
            LogTools logTools = new LogTools();

            foreach (var component in _componets)
            {
                switch (component)
                {
                    case IEngineSettings engineSettings:
                        RegisterEngineSettings(engineSettings);
                        break;
                    case IDataAccessHelperProxySettings dataAccessHelperProxySettings:
                        RegisterDataAccessHelperProxySettings(dataAccessHelperProxySettings);
                        break;
                    case IDataAccessHelperProxy dataAccessHelperProxy:
                        RegisterDataAccessHelperProxy(dataAccessHelperProxy);
                        break;
                    default:
                        logTools.WriteLogToFile<Fatal>(Resources.UnknownComponentFatal);
                        throw new UnknownComponentException(Resources.UnknownComponentFatal);
                }
            }
        }

        public void Validate()
        {
            LogTools logTools = new LogTools();

            if (_engineSettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
            }

            if (_dataAccessHelperProxySettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperProxySettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperProxySettings)));
            }

            if (_dataAccessHelperProxy == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperProxy)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperProxy)));
            }
        }

        public void Run()
        {
            while (true)
            {
                // some work
                Thread.Sleep(1 * 1000);
            }
        }

        #region Register components

        private void RegisterEngineSettings(IEngineSettings engineSettings)
        {
            if (_engineSettings != null)
            {
                string message = string.Format(Resources.RegisterEngineSettingsError, engineSettings.GetType().Name, engineSettings.GetType().Name); 
                
                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _engineSettings = engineSettings;
        }

        private void RegisterDataAccessHelperProxySettings(IDataAccessHelperProxySettings dataAccessHelperProxySettings)
        {
            if (_dataAccessHelperProxySettings != null)
            {
                string message = string.Format(Resources.RegisterDataAccessHelperProxySettingsError, dataAccessHelperProxySettings.GetType().Name, dataAccessHelperProxySettings.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessHelperProxySettings = dataAccessHelperProxySettings;
        }

        private void RegisterDataAccessHelperProxy(IDataAccessHelperProxy dataAccessHelperProxy)
        {
            if (_dataAccessHelperProxy != null)
            {
                string message = string.Format(Resources.RegisterDataAccessHelperProxyError, dataAccessHelperProxy.GetType().Name, dataAccessHelperProxy.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessHelperProxy = dataAccessHelperProxy;
        }

        #endregion
    }
}
