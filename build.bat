@echo off
rem Builds and runs the app using the C# compiler that is already part of Windows.
rem No downloads and no Visual Studio needed.
setlocal
cd /d "%~dp0"
set CSC=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe
if not exist "%CSC%" set CSC=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe
if not exist "%CSC%" (
  echo Could not find csc.exe - .NET Framework 4 is missing.
  pause
  exit /b 1
)
"%CSC%" /nologo /target:winexe /out:Lab2_Mushroom_Bicycle.exe /r:System.dll /r:System.Drawing.dll /r:System.Windows.Forms.dll Lab2_Mushroom_Bicycle\*.cs
if errorlevel 1 (
  echo.
  echo Build failed - see the messages above.
  pause
  exit /b 1
)
start "" Lab2_Mushroom_Bicycle.exe
