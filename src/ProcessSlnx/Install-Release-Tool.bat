:: Installs the NuGet package
@echo off

call Install-Tool.bat Release

:end
if [%1] == [] pause
