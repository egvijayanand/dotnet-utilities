:: Creates a new NuGet package from the project file
@echo off

@echo Deleting existing package
if exist .\FontAwesome\bin\Release\VijayAnand.FontAwesome.1.0.4.nupkg del .\bin\Release\VijayAnand.FontAwesome.1.0.4.nupkg

echo Creating project template ...
dotnet build .\FontAwesome\FontAwesome.csproj -c Release -p:PackageVersion=1.0.4
echo Process completed.
pause