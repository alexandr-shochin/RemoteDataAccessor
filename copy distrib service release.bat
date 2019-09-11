xcopy /s /y RemoteDataAccessor.Common\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.DataAccessProxy\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceEngine\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release Service_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe Service_Distrib_Release
xcopy /s /y RemoteDataAccessor.WindowsServiceSystem\bin\x64\Release\RemoteDataAccessor.WindowsServiceSystem.exe.config Service_Distrib_Release
del Service_Distrib_Release\Modules\RemoteDataAccessor.WindowsServiceSystem.exe
del Service_Distrib_Release\Modules\RemoteDataAccessor.WindowsServiceSystem.exe.config