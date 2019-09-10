xcopy /s /y RemoteDataAccessor.Common\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.DataAccessHelperProxy\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.Engine\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe Service_Distrib_Debug
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe.config Service_Distrib_Debug
del RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe
del RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe.config