:: Creates a new NuGet package from the project file
@echo off

@echo Deleting existing package
if exist .\GoogleMaterial\bin\Release\VijayAnand.GoogleMaterial.1.0.1.nupkg del .\bin\Release\VijayAnand.GoogleMaterial.1.0.1.nupkg

echo Creating project template ...
dotnet build .\GoogleMaterial\GoogleMaterial.csproj -c Release -p:PackageVersion=1.0.1
echo Process completed.
pause