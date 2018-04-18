Contact Application
----------------------
A simple web application created using WCF REST API.

Application has two parts :

1. ContactWebApp : The Asp.Net web application.
2. ContactAPI : RESTFUL API application
3. Database : SQL Server 2008.

How to set the development environment
----------------------------------------

Prerequesites:
---------------
1. Visual Studio 2010 , Dot net framework 4.0
2. Sql Server 2008

Setting up the environment :
-----------------------------
1.Create a local GITHUB repository
2.Downoad all the folders.
3.Create a new database as  "Contacts"
4. Execute the SQL script from the "DBScript" folder
5. Open up both the applications in the Visual Studio 2010.
6. Change the database connection string in the following files 
    1. \ContactAPI\ContactAPI\Web.Config
    2. \ContactAPI\ContactDAL\ContactDAL\App.Config
    3. \ContactApp\ContactWebApp\ContactWebApp
7. Change the "BaseURL" to the URL of the ContactAPI appliction in running on.


Running locally
------------------
1. Run the ContactAPI web service application from visual studio.
2. Run the ContactWebApp web application from visual studio.
