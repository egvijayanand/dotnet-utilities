:: Creates a new NuGet package from the project file
@echo off

if not exist PackageVersion.txt (echo Version file not available && goto end)

set /P packageVersion=<PackageVersion.txt

if "%packageVersion%"=="" (echo Version # not configured && goto end)

echo Version #: %packageVersion%

echo Deleting existing package
if exist .\GoogleMaterial\bin\Release\VijayAnand.GoogleMaterial.%packageVersion%.nupkg del .\bin\Release\VijayAnand.GoogleMaterial.%packageVersion%.nupkg

echo Creating NuGet package ...
dotnet build .\GoogleMaterial\GoogleMaterial.csproj -c Release -p:PackageVersion=%packageVersion%
echo Process completed.

:end
pause