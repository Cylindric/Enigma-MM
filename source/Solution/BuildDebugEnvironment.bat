@ECHO OFF
SETLOCAL
:START

SET SCRIPTPATH=%~dp0
SET SCRIPTDRIVE=%SCRIPTPATH:~0,2%


::Set some common paths
SET REPOSITORY=D:\Minecraft\MCServerRoot
SET ROOT=%SCRIPTPATH%
SET MCSROOT=%ROOT%\Build
SET MCROOT=%MCSROOT%\Minecraft
SET SMROOT=%MCSROOT%\ServerManager
SET CACHEROOT=%MCSROOT%\Cache
SET AVROOT=%MCSROOT%\AlphaVespucci
SET OVERVIEWERROOT=%MCSROOT%\Overviewer
SET BACKUPROOT=%MCSROOT%\Backups


:: Change to the script's path
%SCRIPTDRIVE%
CD %SCRIPTPATH%


:: Create the folder hieararchy
IF NOT EXIST "%MCSROOT%" MKDIR "%MCSROOT%"
IF NOT EXIST "%MCROOT%" MKDIR "%MCROOT%"
IF NOT EXIST "%SMROOT%" MKDIR "%SMROOT%"
IF NOT EXIST "%CACHEROOT%" MKDIR "%CACHEROOT%"
IF NOT EXIST "%AVROOT%" MKDIR "%AVROOT%"
IF NOT EXIST "%OVERVIEWERROOT%" MKDIR "%OVERVIEWERROOT%"
IF NOT EXIST "%BACKUPROOT%" MKDIR "%BACKUPROOT%"


::Copy the files we need to the package
XCOPY /Y "%REPOSITORY%\Minecraft\minecraft_server.jar" "%MCROOT%"
IF EXIST "%REPOSITORY%\Minecraft\Minecraft_Mod.jar" XCOPY /Y "%REPOSITORY%\Minecraft\Minecraft_Mod.jar" "%MCROOT%"
XCOPY /Y "%REPOSITORY%\AlphaVespucci\*" "%AVROOT%"
XCOPY /Y /S "%REPOSITORY%\Overviewer\*" "%OVERVIEWERROOT%"
IF EXIST "%REPOSITORY%\ServerManager\Settings.conf" XCOPY /Y "%REPOSITORY%\ServerManager\Settings.conf" "%SMROOT%"


:END
PAUSE
ENDLOCAL