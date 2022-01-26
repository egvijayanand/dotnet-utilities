:: Creates a new NuGet package from the project file
@echo off

if not exist PackageVersion.txt (echo Version file not available && goto end)

set /P packageVersion=<PackageVersion.txt

if "%packageVersion%"=="" (echo Version # not configured && goto end)

@echo Version #: %packageVersion%

@echo Delete existing package
if exist .\VijayAnand.Helpers\bin\Debug\VijayAnand.Helpers.%packageVersion%.nupkg del .\VijayAnand.Helpers\bin\Debug\VijayAnand.Helpers.%packageVersion%.nupkg

echo Creating NuGet package ...
dotnet build .\VijayAnand.Helpers\VijayAnand.Helpers.csproj -c Debug -p:PackageVersion=%packageVersion%
echo Process completed.

:end
pause