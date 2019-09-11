xcopy /s /y RemoteDataAccessor.Common\bin\x64\Release ConsoleSystem_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.APIProvider\bin\x64\Release ConsoleSystem_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystemEngine\bin\x64\Release ConsoleSystem_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Release ConsoleSystem_Distrib_Release\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Release\RemoteDataAccessor.ConsoleSystem.exe ConsoleSystem_Distrib_Release
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Release\RemoteDataAccessor.ConsoleSystem.exe.config ConsoleSystem_Distrib_Release
del ConsoleSystem_Distrib_Release\Modules\RemoteDataAccessor.ConsoleSystem.exe
del ConsoleSystem_Distrib_Release\Modules\RemoteDataAccessor.ConsoleSystem.exe.config