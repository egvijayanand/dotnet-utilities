:: Creates a new NuGet package from the project file
@echo off

call Create-Tool.bat Debug

:end
if [%1] == [] pause
