xcopy /s /y RemoteDataAccessor.Common\bin\x64\Debug Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.DataAccessHelper\bin\x64\Debug Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.Engine\bin\x64\Debug Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Debug Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Debug\RemoteDataAccessorSystem.exe Distrib_Debug
xcopy /s /y RemoteDataAccessorSystem\bin\x64\Debug\RemoteDataAccessorSystem.exe.config Distrib_Debug
del RemoteDataAccessorSystem\bin\x64\Debug\RemoteDataAccessorSystem.exe
del RemoteDataAccessorSystem\bin\x64\Debug\RemoteDataAccessorSystem.exe.config