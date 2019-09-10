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
        private IDataAccessHelperSettings _dataAccessHelperSettings;
        private IDataAccessHelper _dataAccessHelper;

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
                    case IDataAccessHelperSettings dataAccessHelperSettings:
                        RegisterDataAccessHelperSettings(dataAccessHelperSettings);
                        break;
                    case IDataAccessHelper dataAccessHelper:
                        RegisterDataAccessHelper(dataAccessHelper);
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

            if (_dataAccessHelperSettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperSettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelperSettings)));
            }

            if (_dataAccessHelper == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelper)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.EngineValidateComponentNotInitilizedFatal, nameof(_dataAccessHelper)));
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

        private void RegisterDataAccessHelperSettings(IDataAccessHelperSettings dataAccessHelperSettings)
        {
            if (_dataAccessHelperSettings != null)
            {
                string message = string.Format(Resources.RegisterDataAccessHelperSettingsError, dataAccessHelperSettings.GetType().Name, dataAccessHelperSettings.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessHelperSettings = dataAccessHelperSettings;
        }

        private void RegisterDataAccessHelper(IDataAccessHelper dataAccessHelper)
        {
            if (_dataAccessHelper != null)
            {
                string message = string.Format(Resources.RegisterDataAccessHelperError, dataAccessHelper.GetType().Name, dataAccessHelper.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _dataAccessHelper = dataAccessHelper;
        }

        #endregion
    }
}
