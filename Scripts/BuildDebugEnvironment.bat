@ECHO OFF
SETLOCAL
:START

SET SCRIPTPATH=%~dp0
SET SCRIPTDRIVE=%SCRIPTPATH:~0,2%

SET ROOT=%SCRIPTPATH%
SET MCSROOT=%ROOT%\..\Build

SET SMROOT=%MCSROOT%\
SET MCROOT=%MCSROOT%\Minecraft
SET CACHEROOT=%MCSROOT%\Cache
SET C10TROOT=%MCSROOT%\C10t
SET OVERVIEWERROOT=%MCSROOT%\Overviewer
SET BACKUPROOT=%MCSROOT%\Backups
SET MAPROOT=%MCSROOT%\Maps


CD %SCRIPTDRIVE%
CD %MCSROOT%

:: Create the folder hieararchy
IF NOT EXIST "%MCSROOT%" MKDIR "%MCSROOT%"
IF NOT EXIST "%MCROOT%" MKDIR "%MCROOT%"
IF NOT EXIST "%SMROOT%" MKDIR "%SMROOT%"
IF NOT EXIST "%CACHEROOT%" MKDIR "%CACHEROOT%"
IF NOT EXIST "%C10TROOT%" MKDIR "%C10TROOT%"
IF NOT EXIST "%OVERVIEWERROOT%" MKDIR "%OVERVIEWERROOT%"
IF NOT EXIST "%BACKUPROOT%" MKDIR "%BACKUPROOT%"
IF NOT EXIST "%MAPROOT%" MKDIR "%MAPROOT%"

IF NOT EXIST "%MCROOT%\minecraft_server.jar" GOTO GET_MINECRAFT
:GET_MINECRAFT_DONE

GOTO END

:GET_MINECRAFT
SET MCSRC="https://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar"

GOTO GET_MINECRAFT_DONE


::Set some common paths
SET REPOSITORY=%EMMSERVERBASE%
IF NOT EXIST "%REPOSITORY%" GOTO HELP

SET ROOT=%SCRIPTPATH%
SET MCSROOT=%ROOT%\..\Build

SET MCROOT=%MCSROOT%\Minecraft
SET SMROOT=%MCSROOT%\
SET CACHEROOT=%MCSROOT%\Cache
SET C10TROOT=%MCSROOT%\C10t
SET OVERVIEWERROOT=%MCSROOT%\Overviewer
SET BACKUPROOT=%MCSROOT%\Backups
SET MAPROOT=%MCSROOT%\Maps


:: Change to the script's path
%SCRIPTDRIVE%
CD %SCRIPTPATH%


:: Create the folder hieararchy
IF NOT EXIST "%MCSROOT%" MKDIR "%MCSROOT%"
IF NOT EXIST "%MCROOT%" MKDIR "%MCROOT%"
IF NOT EXIST "%SMROOT%" MKDIR "%SMROOT%"
IF NOT EXIST "%CACHEROOT%" MKDIR "%CACHEROOT%"
IF NOT EXIST "%C10TROOT%" MKDIR "%C10TROOT%"
IF NOT EXIST "%OVERVIEWERROOT%" MKDIR "%OVERVIEWERROOT%"
IF NOT EXIST "%BACKUPROOT%" MKDIR "%BACKUPROOT%"
IF NOT EXIST "%MAPROOT%" MKDIR "%MAPROOT%"


::Copy the files we need to the package
XCOPY /Y "%REPOSITORY%\Minecraft\minecraft_server.jar" "%MCROOT%"
IF EXIST "%REPOSITORY%\Overviewer" XCOPY /Y /S "%REPOSITORY%\Overviewer\*" "%OVERVIEWERROOT%"
IF EXIST "%REPOSITORY%\c10t" XCOPY /Y /S "%REPOSITORY%\c10t\*" "%C10TROOT%"

CD %MCROOT:~0,2%
CD "%MCROOT%"
ECHO stop | java -jar "%MCROOT%\minecraft_server.jar" nogui
GOTO END

:HELP
ECHO The environment variable EMMSERVERBASE should point to a repository where EMM test sources can be found
GOTO END

:END
ENDLOCAL