:: Installs the NuGet package
@echo off

if defined MyGetSource (set nugetSource=%MyGetSource%) else (call Error "MyGet folder source path is not defined." & goto end)

if defined MyGetServer (set nugetServer=%MyGetServer%) else (call Error "MyGet hosted source path is not defined." & goto end)

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." & goto end)

set /P packageName=<PackageName.txt

if [%packageName%]==[] (call Error "Package name not configured." & goto end)

:: Package Version

if not exist PackageVersion.txt (call Error "Package version file not available." & goto end)

set /P packageVersion=<PackageVersion.txt

if [%packageVersion%]==[] (call Error "Package version # not configured." & goto end)

:: Existence Check

if not exist .\ProcessSlnx\bin\Release\%packageName%.%packageVersion%.nupkg call Error "NuGet package not available ..." & goto end

:: Modify .NET SDK Version

::if exist global.json (call Error "Verify the .NET SDK Version" & goto end)
::if exist global.json.net6.bak ren global.json.net6.bak global.json

call Info ".NET SDK Version"
dotnet --version

:: Push the Package

echo.
call Info "Pushing %packageName% ver. %packageVersion% to MyGet ..."

dotnet nuget push .\ProcessSlnx\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error "Template package folder push failed.")

echo.
nuget add .\ProcessSlnx\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Template package hosted push failed.")

:: Revert the changes
::if exist global.json ren global.json global.json.net6.bak

:end
pause
