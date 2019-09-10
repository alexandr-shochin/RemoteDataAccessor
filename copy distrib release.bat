xcopy /s /y RemoteDataAccessor.Common\bin\x64\Release Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.DataAccessHelper\bin\x64\Release Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.Engine\bin\x64\Release Distrib_Release\Modules
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Release Distrib_Release\Modules
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Release\RemoteDataAccessorSystem.exe Distrib_Release
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Release\RemoteDataAccessorSystem.exe.config Distrib_Release
del RemoteDataAccessorSystem\bin\x64\Release\RemoteDataAccessorSystem.exe
del RemoteDataAccessorSystem\bin\x64\Release\RemoteDataAccessorSystem.exe.config