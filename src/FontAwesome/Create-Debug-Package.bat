:: Creates a new NuGet package from the project file
@echo off

set config=Debug

if not exist PackageVersion.txt (call Error "Version file not available." & goto end)

set /P packageVersion=<PackageVersion.txt

if [%packageVersion%]==[] (call Error "Version # not configured." & goto end)

call Info "Version #: %packageVersion%"

echo .\FontAwesome\bin\%config%\VijayAnand.FontAwesome.%packageVersion%.nupkg

call Info "Deleting existing package ..."
if exist .\FontAwesome\bin\%config%\VijayAnand.FontAwesome.%packageVersion%.nupkg del .\FontAwesome\bin\%config%\VijayAnand.FontAwesome.%packageVersion%.nupkg

call Info "Creating NuGet package ..."

dotnet build .\FontAwesome\FontAwesome.csproj -c %config% -p:PackageVersion=%packageVersion% -p:ContinuousIntegrationBuild=true

if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Package creation failed.")

:end
pause
