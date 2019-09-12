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
using RemoteDataAccessor.WindowsServiceEngine.Properties;

namespace RemoteDataAccessor.WindowsServiceEngine
{
    public class WindowsServiceEngineCore : IWindowsServiceEngine
    {
        private readonly IComponent[] _componets;

        private IWindowsServiceEngineSettings _engineSettings;
        private IDataAccessProxySettings _dataAccessProxySettings;
        private IDataAccessProxy _dataAccessProxy;

        public WindowsServiceEngineCore(IComponent[] componets)
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
                    case IWindowsServiceEngineSettings engineSettings:
                        RegisterWindowsServiceEngineSettings(engineSettings);
                        break;
                    case IDataAccessProxySettings dataAccessProxySettings:
                        RegisterDataAccessProxySettings(dataAccessProxySettings);
                        break;
                    case IDataAccessProxy dataAccessProxy:
                        RegisterDataAccessProxy(dataAccessProxy);
                        break;
                    default:
                        logTools.WriteLogToFile<Info>(string.Format(Resources.UnknownComponentFatal, component.GetType().Name));
                        break;
                }
            }
        }

        public void Validate()
        {
            LogTools logTools = new LogTools();

            if (_engineSettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
            }

            if (_dataAccessProxySettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_dataAccessProxySettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_dataAccessProxySettings)));
            }

            if (_dataAccessProxy == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_dataAccessProxy)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.WindowsServiceEngineValidateComponentNotInitilizedFatal, nameof(_dataAccessProxy)));
            }
        }

        public void Run()
        {
            while (true)
            {
                List<string> dataFromApi = _dataAccessProxy.GetData();

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Info>(string.Join(",", dataFromApi));

                // some work
                Thread.Sleep(1 * 1000);
            }
        }

        #region Register components

        private void RegisterWindowsServiceEngineSettings(IWindowsServiceEngineSettings engineSettings)
        {
            if (_engineSettings != null)
            {
                string message = string.Format(Resources.RegisterWindowsServiceEngineSettingsError, engineSettings.GetType().Name, engineSettings.GetType().Name); 
                
                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _engineSettings = engineSettings;
        }

        private void RegisterDataAccessProxySettings(IDataAccessProxySettings dataAccessProxySettings)
        {
            if (_dataAccessProxySettings != null)
            {
                string message = string.Format(Resources.RegisterDataAccessProxySettingsError, dataAccessProxySettings.GetType().Name, dataAccessProxySettings.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessProxySettings = dataAccessProxySettings;
        }

        private void RegisterDataAccessProxy(IDataAccessProxy dataAccessProxy)
        {
            if (_dataAccessProxy != null)
            {
                string message = string.Format(Resources.RegisterDataAccessProxyError, dataAccessProxy.GetType().Name, dataAccessProxy.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessProxy = dataAccessProxy;
        }

        #endregion
    }
}
