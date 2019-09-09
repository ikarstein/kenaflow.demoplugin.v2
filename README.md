# Install

1. Install chocolatey
cmd.exe:  
`@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"`  
or powershell.exe:  
`Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))`  
1. Install Visual Studio 2019 Build Tools  
	`choco install visualstudio2019buildtools`

# Steps for Setup

1. Edit `kenaflow.demoplugin.csproj`:
    1. Modify path to `kenaflow.lib` 
		```XML
	    <Reference Include="kenaflow.lib">
			<HintPath>c:\kenaflow\kenaflow.lib.dll</HintPath>
			<Private>False</Private>
		</Reference>
		```
		
1. Edit `kenaflow.demoplugin.csproj.user`:
	1. Modify path to `kenaflow.exe`
	1. Modify path to demo workflow
1. Open solution
1. restore Nuget packages
1. Compile

# Project

This is a Demo Plugin for kenaflow (>= 3.0.12).

Part of kenaflow (https://kenaflow.com)

Copyright by kenaro GmbH (https://www.kenaro.com)

Written by Ingo Karstein


