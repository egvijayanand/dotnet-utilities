:: Installs the NuGet package
@echo off

call Install-Template.bat Debug

:end
if [%1] == [] pause
