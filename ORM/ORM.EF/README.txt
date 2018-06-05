Entity Framework : 

1.	Create and add new Class Project to the Solution. 
2.	Right-click on newly added project in Visual Studio and select "Manage NuGet Packages". 
3.	Search for "Entity Framework" and install it on the Project. 
4.	Add connection string to database in web.config file for application project that will be using the class project containing Entity Framework. 
5.	Create Context class which inherits from / extends DbContext class. 
6.	Create necessary  domain entity classes and map them to the database via fluent api.
7.	Use the Visual Studio Package Manager Console to create code-first migrations to create and update the database as required. 
	Enabling migrations will create a "Migrations" folder and a "Configuration" class. 

Package Manager Console commands : 

	To enable migrations                                                 : enable-migrations
	To create/add a new migration                                        : add-migration "Migration Name"
	To create/update the database and run all the migrations             : update-database
	To update the database to a specified migration                      : update-database -TargetMigration:"Migration Name"
