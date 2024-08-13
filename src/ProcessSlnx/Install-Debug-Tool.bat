:: Installs the NuGet package
@echo off

call Install-Tool.bat Debug

:end
if [%1] == [] pause
