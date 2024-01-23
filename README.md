**** ASP.NET Core Web API for a Guest entity ****
Follow below step to run the example on local 

1) Restore the Data base in local using backup file https://github.com/PrashSingh90/TimeZoneDemo/blob/main/GuestApp/GuestApp_DBBackup.bacpac
2) set GuestAppConnection connection string  to your Local db.
3) first time register user using "/api/UserAuth/register"
4) Then Login with user name and password "/api/UserAuth/login"
5) Set Bearer token using authorition button.


Things need to be implemented .
1) CQRS pattern
2) Logging
3) Unit tests 
