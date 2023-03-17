:: Installs the NuGet package
@echo off

call Install-Template.bat Release

:end
if [%1] == [] pause
