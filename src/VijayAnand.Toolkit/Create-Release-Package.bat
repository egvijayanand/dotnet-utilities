:: Creates a new NuGet package from the project file
@echo off

if not exist PackageVersion.txt (echo Version file not available && goto end)

set /P packageVersion=<PackageVersion.txt

if [%packageVersion%]==[] (echo Version # not configured && goto end)

@echo Version #: %packageVersion%

@echo Delete existing package
if exist .\VijayAnand.Toolkit\bin\Release\VijayAnand.Toolkit.%packageVersion%.nupkg del .\VijayAnand.Toolkit\bin\Release\VijayAnand.Toolkit.%packageVersion%.nupkg

echo Creating NuGet package ...
dotnet build .\VijayAnand.Toolkit\VijayAnand.Toolkit.csproj -c Release -p:PackageVersion=%packageVersion%
echo Process completed.

:end
pause