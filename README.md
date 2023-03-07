# full-stack-web-app

##  Project Background
  This is a Full Stack Web Application Program developed with ASP. Net Core API and Angular. This project implements the CRUD operation on the API Resource,
   a [Student](https://github.com/irfaniskandar-23/full-stack-web-app/blob/main/backend/student%20API/Models/Student.cs) Model.
   The developed with .Net Core will be consumed by the Angular Application
    <br />
   
   1) ASP.NET Core API is used to developed the students API as follows:
   

<img src="https://user-images.githubusercontent.com/59824144/223435104-acf189a7-72f3-4772-9036-3060c5085f0e.png" width="1000" height="400">
  
  
  2) Angular Application Consuming the Backend API

   <img src="https://user-images.githubusercontent.com/59824144/223436621-48710956-3b60-49a3-a788-24ce72eb6ec4.png" width="1000" height="400">
   


To clone this repo, execute following command
   
```
git clone https://github.com/irfaniskandar-23/full-stack-web-app.git
```
 *Note that the backend and frontend are in seperated directories*
 
 <br />
 
## Backend
the Backend for this  project is develpoed with ASP.Net Core Web API (.Net 6.0). The API can be monitor in Swagger UI or Postman.
This project uses Microsoft SQL Server Database and Entity Framework Code First Approach. Following are the steps to setup the database

### 1. Dependencies
In Visual Studio, install these dependencies from Nuget Packages
1. Entity Framework Core Sql Server
2. Entity Framework core Tools
3. Swashbuckle.AspNetCore.Annotations

> Note: Make sure to install all the required dependencies for the program to execture as expected

### 2. Database
Once all dependencies are installed, head to [setting.json](https://github.com/irfaniskandar-23/full-stack-web-app/blob/main/backend/student%20API/appsettings.json)
and add your connection string. The conncetiong field may varies depend on your SQL Server Configuration

```
 "ConnectionStrings": {
    "FullStackConnectionString": "server=IAM_ISKANDAR\\SQLEXPRESS;database=fullStackTest;Trusted_Connection=True;Encrypt=False"
  }
```
### 3. Migration
Once the connection string is setup, now is the time to migrate the models into database tables. launch the Package Manager Console and execute following command

```
> add-migration "migration-name"
> update-database
```
> *Note: remove existing migration folder before executing the above command*

The Students  table will be created in the SQL Server database
