:: Creates a new NuGet package from the project file
@echo off

call Create-Template.bat Debug

:end
if [%1] == [] pause
