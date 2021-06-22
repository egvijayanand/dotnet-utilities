:: Creates a new NuGet package from the project file
@echo off

@echo Deleting existing package
if exist .\FontAwesome\bin\Release\VijayAnand.FontAwesome.1.0.1.nupkg del .\bin\Release\VijayAnand.FontAwesome.1.0.1.nupkg

echo Creating project template ...
dotnet build .\FontAwesome\FontAwesome.csproj -c Release
echo Process completed.
pause