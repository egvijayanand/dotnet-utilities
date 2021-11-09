:: Creates a new NuGet package from the project file
@echo off

if not exist PackageVersion.txt (echo Version file not available && goto end)

set /P packageVersion=<PackageVersion.txt

if "%packageVersion%"=="" (echo Version # not configured && goto end)

echo Version #: %packageVersion%

echo Deleting existing package
if exist .\FontAwesome\bin\Debug\VijayAnand.FontAwesome.%packageVersion%.nupkg del .\bin\Debug\VijayAnand.FontAwesome.%packageVersion%.nupkg

echo Creating NuGet package ...
dotnet build .\FontAwesome\FontAwesome.csproj -c Debug -p:PackageVersion=%packageVersion%
echo Process completed.

:end
pause