@echo off
forfiles /P . /M *.cs /C "cmd /c 7z a -tzip solution.zip @file"
7z a -tzip solution.zip aicup2019.csproj
@echo on