using System.Threading;

using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Common.Interfaces.Component;
using RemoteDataAccessor.Common.Interfaces.Helpers;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.ConsoleSystemEngine.Properties;

namespace RemoteDataAccessor.ConsoleSystemEngine
{
    public class ConsoleSystemEngineCore : IConsoleSystemEngine
    {
        private readonly IComponent[] _componets;

        private IConsoleSystemEngineSettings _engineSettings;
        private IAPIProviderSettings _apiProviderSettings;
        private IAPIProvider _apiProvider;

        public ConsoleSystemEngineCore(IComponent[] componets)
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
                    case IConsoleSystemEngineSettings engineSettings:
                        RegisterConsoleSystemEngineSettings(engineSettings);
                        break;
                    case IAPIProviderSettings apiProviderSettings:
                        RegisterApiProviderSettings(apiProviderSettings);
                        break;
                    case IAPIProvider apiProvider:
                        RegisterApiProvider(apiProvider);
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
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_engineSettings)));
            }

            if (_apiProviderSettings == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_apiProviderSettings)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_apiProviderSettings)));
            }

            if (_apiProvider == null)
            {
                logTools.WriteLogToConsole<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_apiProvider)));
                logTools.WriteLogToFile<Fatal>(string.Format(Resources.ConsoleSystemEngineValidateComponentNotInitilizedFatal, nameof(_apiProvider)));
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

        private void RegisterConsoleSystemEngineSettings(IConsoleSystemEngineSettings engineSettings)
        {
            if (_engineSettings != null)
            {
                string message = string.Format(Resources.RegisterConsoleSystemEngineSettingsError, engineSettings.GetType().Name, engineSettings.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _engineSettings = engineSettings;
        }

        private void RegisterApiProviderSettings(IAPIProviderSettings apiProviderSettings)
        {
            if (_apiProviderSettings != null)
            {
                string message = string.Format(Resources.RegisterApiProviderSettingsError, apiProviderSettings.GetType().Name, apiProviderSettings.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _apiProviderSettings = apiProviderSettings;
        }

        private void RegisterApiProvider(IAPIProvider apiProvider)
        {
            if (_apiProvider != null)
            {
                string message = string.Format(Resources.RegisterApiProviderError, apiProvider.GetType().Name, apiProvider.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Error>(message);
                logTools.WriteLogToFile<Error>(message);
            }

            _apiProvider = apiProvider;
        }

        #endregion
    }
}
