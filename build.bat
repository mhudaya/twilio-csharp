@echo Off
REM set config=%1
REM if "%config%" == "" (
REM    set config=Release
REM )

REM set version=
REM if not "%PackageVersion%" == "" (
REM    set version=-Version %PackageVersion%
REM )

REM Clean Source
REM %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.2013.sln /p:Configuration=FX35 /t:Clean
REM %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.2013.sln /p:Configuration=PCL /t:Clean

REM Package restore
cmd /c %nuget% restore src\Twilio.2013.sln -NoCache -NonInteractive

REM Build Source
REM %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.2013.sln /p:Configuration="Debug - FX35" /p:Platform="Any CPU" /p:VRevision=%BuildCounter% /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:true /p:BuildInParallel=true /p:RestorePackages=true /t:Rebuild
REM if not "%errorlevel%"=="0" goto failure
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.2013.sln /p:Configuration="Debug - PCL" /p:Platform="Any CPU" /p:VRevision=%BuildCounter% /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:true /p:BuildInParallel=true /p:RestorePackages=true /t:Rebuild
if not "%errorlevel%"=="0" goto failure

REM Run Unit tests
REM "%GallioEcho%" /v:Verbose src\SimpleRestClient.Tests\bin\FX35\SimpleRestClient.Tests.dll
REM if not "%errorlevel%"=="0" goto failure
REM "%GallioEcho%" /v:Verbose src\Twilio.Api.Net35.Tests\bin\FX35\Twilio.Api.Net35.Tests.dll
REM if not "%errorlevel%"=="0" goto failure

REM "%GallioEcho%" /v:Verbose src\SimpleRestClient.Tests\bin\PCL\SimpleRestClient.Tests.dll
REM if not "%errorlevel%"=="0" goto failure
REM "%GallioEcho%" /v:Verbose src\Twilio.Api.Pcl.Tests\bin\PCL\Twilio.Api.Pcl.Tests.dll
REM if not "%errorlevel%"=="0" goto failure

REM Package Folders Setup
rd download /s /q  REM delete the old stuff

if not exist download mkdir download
if not exist download\package mkdir download\package

if not exist download\package\twilio mkdir download\package\twilio
if not exist download\package\twilio\lib mkdir download\package\twilio\lib
if not exist download\package\twilio\lib\net35 mkdir "download\package\twilio\lib\net35"
if not exist download\package\twilio\lib\net40 mkdir "download\package\twilio\lib\net40"
REM if not exist download\package\twilio\lib\portable-windows8-net45 mkdir "download\package\twilio\lib\portable-windows8-net45"
if not exist download\package\twilio\lib\portable-net403+sl5+netcore45+wp8+MonoAndroid1+MonoTouch1 mkdir "download\package\twilio\lib\portable-net403+sl5+netcore45+wp8+MonoAndroid1+MonoTouch1"
if not exist download\package\twilio\lib\portable-net403+sl5+netcore45+wp8 mkdir "download\package\twilio\lib\portable-net403+sl5+netcore45+wp8"

REM portable-net403+netcore45+MonoAndroid1+MonoTouch1
REM portable-net403+sl5+netcore45+wp8+MonoAndroid1+MonoTouch1
REM portable-net45+netcore45+MonoAndroid1+MonoTouch1
REM portable-net4+sl5+MonoAndroid1+MonoTouch1

REM Copy files into Nuget Package structure
copy LICENSE.txt download
copy src\Twilio.Api.Net35\bin\FX35\Twilio.Api.* "download\package\twilio\lib\net35\"
copy src\Twilio.Api.Pcl\bin\PCL\Twilio.Api.* "download\package\twilio\lib\net40\"
REM copy src\Twilio.Api.Pcl\bin\PCL\Twilio.Api.* "download\package\twilio\lib\portable-windows8-net45\"
copy src\Twilio.Api.Pcl\bin\PCL\Twilio.Api.* "download\package\twilio\lib\portable-net403+sl5+netcore45+wp8+MonoAndroid1+MonoTouch1\"
copy src\Twilio.Api.Pcl\bin\PCL\Twilio.Api.* "download\package\twilio\lib\portable-net403+sl5+netcore45+wp8\"

REM Create Packages
REM mkdir Build

REM FOR /F "tokens=* delims=" %%x in (src/version.txt) DO SET ver=%%x
REM cmd /c %nuget% pack "Twilio.nuspec" -Version %ver%.%BuildCounter%-alpha -BasePath download\package\twilio -o download
REM if not "%errorlevel%"=="0" goto failure

:success

REM use github status API to indicate commit compile success

exit 0

:failure

REM use github status API to indicate commit compile success

exit -1
