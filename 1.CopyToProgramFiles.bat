@set @dummy=0/*
@echo off

NET FILE 1>NUL 2>NUL
if "%ERRORLEVEL%" neq "0" (
  cscript //nologo //E:JScript "%~f0" %*
  exit /b %ERRORLEVEL%
)

REM �Ǘ��Ҍ����Ŏ��s���������� ��������

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"

cd %~dp0

set TARGETDIR="C:\Program Files\McpJikken\"

IF NOT EXIST %TARGETDIR% (
    MKDIR %TARGETDIR%
)

taskkill -im ReviewWithOurCodingRulesMcpServer.exe -f

dotnet build ".\McpJikkenApp.sln" 

xcopy /Y /S /I ".\ReviewWithOurCodingRulesMcpServer\bin\x64\Debug\net9.0\" %TARGETDIR%

pause
REM �Ǘ��Ҍ����Ŏ��s���������� �����܂�

goto :EOF
*/
var cmd = '"/c ""' + WScript.ScriptFullName + '" ';
for (var i = 0; i < WScript.Arguments.Length; i++) cmd += '"' + WScript.Arguments(i) + '" ';
(new ActiveXObject('Shell.Application')).ShellExecute('cmd.exe', cmd + ' "', '', 'runas', 1);
