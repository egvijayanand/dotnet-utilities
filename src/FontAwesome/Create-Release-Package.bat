:: Creates a new NuGet package from the project file
@echo off

@echo Deleting existing package
if exist .\FontAwesome\bin\Release\VijayAnand.FontAwesome.1.0.2.nupkg del .\bin\Release\VijayAnand.FontAwesome.1.0.2.nupkg

echo Creating project template ...
dotnet build .\FontAwesome\FontAwesome.csproj -c Release -p:PackageVersion=1.0.2
echo Process completed.
pause