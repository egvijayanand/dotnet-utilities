:: Creates a new NuGet package from the project file
@echo off

if [%1]==[] (call Error "Build configuration input is not provided." & pause & goto end)

set config=%1

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." & goto end)

set /P packageName=<PackageName.txt

if [%packageName%]==[] (call Error "Package name not configured." & goto end)

:: Package Version

if not exist PackageVersion.txt (call Error "Version file not available." & goto end)

set /P packageVersion=<PackageVersion.txt

if [%packageVersion%]==[] (call Error "Version # not configured." & goto end)

call Info ".NET SDK Version"

dotnet --version

call Info "Deleting existing package ..."

if exist .\FontAwesome\bin\%config%\%packageName%.%packageVersion%.nupkg del .\FontAwesome\bin\%config%\%packageName%.%packageVersion%.nupkg

call Info "Creating %packageName% ver. %packageVersion% NuGet package in %config% mode ..."

dotnet build .\FontAwesome\FontAwesome.csproj -c %config% -p:PackageVersion=%packageVersion% -p:ContinuousIntegrationBuild=true

if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Package creation failed.")

:end
