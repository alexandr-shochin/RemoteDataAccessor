xcopy /s /y RemoteDataAccessor.Common\bin\x64\Debug ConsoleSystem_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.APIProvider\bin\x64\Debug ConsoleSystem_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystemEngine\bin\x64\Debug ConsoleSystem_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Debug ConsoleSystem_Distrib_Debug\Modules
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Debug\RemoteDataAccessor.ConsoleSystem.exe ConsoleSystem_Distrib_Debug
xcopy /s /y RemoteDataAccessor.ConsoleSystem\bin\x64\Debug\RemoteDataAccessor.ConsoleSystem.exe.config ConsoleSystem_Distrib_Debug
del ConsoleSystem_Distrib_Debug\Modules\RemoteDataAccessor.ConsoleSystem.exe
del ConsoleSystem_Distrib_Debug\Modules\RemoteDataAccessor.ConsoleSystem.exe.config