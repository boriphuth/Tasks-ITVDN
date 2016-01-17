rem echo off
echo DATE:
date /t
echo TIME: 
time /t
sqlcmd -s 340-0 -U 123 -P 123 -d Store -i ..\Queries\SQLQueryDropDB.sql" -o ..\Reports\DropDBResult.txt
start notepad DropDBResult.txt
rem pause