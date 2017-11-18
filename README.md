# Financial Manager Sample
This project uses repository pattern in order to centralize the data source of the system.

Before to launch the app, please keep in mind the following considerations:

1. The app works on Sql Server local db, so  please make sure you have installed Sql Server.
2. From Package Manager Console at Infrastructure Project, hit "enable-migrations" command.
3. From Package Manager Console at Infrastructure Project, type "update-database" in order to create/update the database
4. From Package Manager Console at WebApp Project, hit "enable-migrations" command.
5. From Package Manager Console at WebApp Project, type "update-database" in order to create/update the database
6. By starting the solution, the web app and the web service will run.

##How to login to the application?
You can use one of the following user credentials to enter to the application, each user has a assigned role with different permissions.

###Assistant
assistant@test.com
Assistant_2017

###Manager
manager@test.com
Manager_2017

###Superintendent
superintendent@test.com
Superintendent_2017

###Administrator
administrator@test.com
Administrator_2017

##Some Technical overview
- EF Database First.
- Repository Pattern.
- Inversion of Control.
- Unity Factory.
- Domain Driven Design.
- WCF.

##TODO
- Implement security over the API access from client.

##Author
Angel Soto
dreamensys@gmail.com


