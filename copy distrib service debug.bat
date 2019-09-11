xcopy /s /y RemoteDataAccessor.Common\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.DataAccessProxy\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceEngine\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug Service_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe Service_Distrib_Debug
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Debug\RemoteDataAccessor.WindowsServiceSystem.exe.config Service_Distrib_Debug
del Service_Distrib_Debug\Modules\RemoteDataAccessor.WindowsServiceSystem.exe
del Service_Distrib_Debug\Modules\RemoteDataAccessor.WindowsServiceSystem.exe.config