@echo off
echo "Enter the IP address for verification or "quit" to shutdown the program"
:start
set /P "var=Input: "
if "%var%" NEQ "quit" goto next
exit
:next
"%CD%\IP matching.exe" %var%
goto :start
