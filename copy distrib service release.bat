xcopy /s /y RemoteDataAccessor.Common\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.DataAccessHelperProxy\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.Engine\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe Service_Distrib_Release
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe.config Service_Distrib_Release
del RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe
del RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe.config