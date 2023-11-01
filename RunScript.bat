ECHO off
sqlcmd -S localhost -E -i DatabaseScript.sql
ECHO .
ECHO if no errors appear DB was created
PAUSE