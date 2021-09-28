:: Creates a new NuGet package from the project file
@echo off

@echo Deleting existing package
if exist .\GoogleMaterial\bin\Release\VijayAnand.GoogleMaterial.1.0.0.nupkg del .\bin\Release\VijayAnand.GoogleMaterial.1.0.0.nupkg

echo Creating project template ...
dotnet build .\GoogleMaterial\GoogleMaterial.csproj -c Release -p:PackageVersion=1.0.0
echo Process completed.
pause