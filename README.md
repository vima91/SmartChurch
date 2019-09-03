# SmartChurch

SmartChurch (.net core 2.2 web app) setup and configuration steps: (Windows 10)

1- Publish.

2- Install prerequisites:

2.1- IIS:

	2.1.1- Copy publish folder into c:/inetpub/ (wwwroot will replace the existing one if any)
	
	2.1.2- In Application Pools> Create new Application Pool with .NET CLR version: No Managed Code
	
	2.1.3- In Sites> Right click on "Default Web Site" and "Add Application", 		
	set name and select created app pool and point to copied folder of the app.
	
2.2- dotnet-hosting-2.2.1-win.exe

2.3- SSMS-Setup-ENU.exe

2.4- vc_redist.x86.exe AND vc_redist.x64.exe

3- Adjust appSettings to point to server and database.

4- Apply seed data in Seed.sql: (Seed.sql file can be extracted from solution)

4.1- run in cmd: (Assuming instance name is MSSQLSERVER and Db name is SmartChurch)
	sqlcmd -S .\MSSQLSERVER -d SmartChurch -i "Seed.sql"

8- Try start.

6- If needed, create login in sql server with name: "IIS APPPOOL\SmartChurch"

7- Check APIs Url and update Angular project Base_Url with said Url.

8- Deploy Angular App to separate Website on IIS.
