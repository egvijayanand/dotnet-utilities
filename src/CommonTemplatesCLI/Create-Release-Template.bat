:: Creates a new NuGet package from the project file
@echo off

call Create-Template.bat Release

:end
if [%1] == [] pause
