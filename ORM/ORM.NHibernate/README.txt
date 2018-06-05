Nhibernate - FluentMigrator : 

1.	Create and add new Class Project to the Solution. 
2.	Right-click on newly added project in Visual Studio and select "Manage NuGet Packages". 
3.	Search for and install the following packages : "Nhibernate", "FluentNhibernate" and "FluentMigrator". 
4.	Add connection string to database in web.config file for application project that will be using the class project containing Nhibernate. 
5.	Create all the classes which can be found in the "Repositories" folder in this project. 
6.	Create necessary  domain entity classes and map them to the database using FluentNhibernate as can be seen in the "Mappings" folder in this project.
7.	Create "Migrations" folder and write the database migrations as can be seen in the "Migrations" folder in this project. 
8.	Create "migrations.proj" file and "MSBuildMigrator.Migrate.bat" file as can be seen in this project. 
	The "migrations.proj" file contains migration configuration information and tasks for FluentMigrator to execute. 
	In order to run FluentMigrator and to execute the migrations that are configure in this file we first need to open up a command line window with Administrator access. 
	Then navigate to where the FluentMigrator is installed on your system, i.e. "C:\Dev\ApplicationTemplate\packages\FluentMigrator.1.6.2\tools". 
	We need to navigate to the folder where the "Migrate.exe" is situated. 
	Then we need to execute the following migrate command that is in the "MSBuildMigrator.Migrate.bat" file. 
	You will need to configure the database connection string for your own environment. 
	The "--assembly" configuration needs to be the filepath and dll of your Nhibernate project. 
	The "--task" configuration is the desired task that you want FluentMigrator to execute. 
	These are listed in the "migrations.proj" file. You can use the "Target" element's "Name" attribute.
	i.e. in our case it could be the "Migrate", "MigrateRollBack", "MigrateRollbackAll" or "ListMigrations" task. 
	It seems like before you are able to run the migrations, you first need to create the empty database in SQL. 
