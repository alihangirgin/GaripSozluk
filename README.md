# GARIP SOZLUK
Garip Sozluk is .Net Core web application that has [EkşiSözlük](https://www.eksisozluk.com) EksiSozluk look like interface and features.
![alt text](https://i.imgur.com/XOeR7WQ.png)
## Prerequisites
  - Microsoft Visual Studio
  - .NET Core 3.1
  - Microsoft SQL Server Management Studio
  - PostgreSql
## Techs
  - C#
  - Asp .Net Core MVC
  - Asp .Net Core Web Api
  - Entity Framework Core
  - Language Integrated Query(LINQ)
  - SQL
  - Object-Oriented Programming
  - Generic Repository Pattern
  - HTML
  - Bootsrap
  - CSS
  - Javascript
  - Ajax
  - JQuery

## Installation
  - Download and open with Visual Studio
  - Open Package Manager Console in Visual Studio
  - Type the following command:
```sh
 update-database
```
  - Run WebApp and Api as Multiple startup project

## Architecture of the Project
As it is a basic and instructive project, a simple non-advanced layer is used. Four layers were used.
- GaripSozluk.Business Layer
Here are the services and their interfaces we have defined to reduce the workload on the controller. Crud operations are defined by calling repositories in the methods in the services and the parameters returned from the services are sent to the controllers as a view model. Therefore, it is dependent on data layer and common layer. Also, each method is defined in the interface.
- GaripSozluk.Common Layer
Here, view models that carrying data between the business layer and controllers and carrying data from the controller to the view are defined. Because it is not a correct approach to send the data read from the database directly to the view.
- GaripSozluk.Data Layer
Database related classes are defined here. Domain and mapping files were used to create the database. Repositories are defined for doing crud operations on the database.
- GaripSozluk.WebApp Layer
This is where the classic mvc pattern is located. Controllers receive data from services and send the incoming data to the views via the view model. So it is dependent on business and common layers.

## Database Design
Entity framework code first approach is used to create the database. Entities are defined in classes within the domain folder in the data layer and their relationships are defined in the mapping folder. Their configuration is in the GaripSozlukDbContext file.
### Entities
- BlockedUser
- Entry
- EntryRating
- PostCategory
- Role
- User
### Entity Relationships
- User 1-n BlockedUsers
- User 1-n Posts
- User 1-n Entries
- User 1-n Ratings
- Category 1-n Posts
- Post 1-n Entries
- Entry 1-n Ratings
### Database Diagram
![alt text](https://i.imgur.com/WBLL246.png)

## Controllers
### Account Controller
AspNetCore.Identity is integrated for account actions like login and regiter
- Account/Login-> Login 
- Account/Register-> Register
- Account/Logout-> Logout
### ApiPost Controller
It was created to see how MVC and API projects make a connection. A service method has been defined to get post list received from Api that I created.
- ApiPost/GetPosts->to get posts from my Api
### Entry Controller
Entry is basically the comments of the posts. Each user can create multiple comments on each post and can rate each of them.
- Entry/Like-> to like entries
- Entry/Dislike-> to dislike entries
- Entry/AddEntry-> to add entry
- Entry/UpdateEntry-> to update entry

### Home Controller
Home page displays the selected post in the selected category with entries.
- Home/Index-> main page of the app

### PostCategory Controller
Post categories are the categories to which posts belongs to.
- PostCategory/AddPostCategory-> to add postcategory
- PostCategory/UpdatePostCategory-> to update postcategory

### Post Controller
Posts are titles that can be commented on with entries.
- Post/Random-> to get random post 
- Post/AddPost-> to add post
- Post/UpdatePost-> to update post
- Post/Search-> for simple search from posts
- Post/DetailedSearch-> for detailed search from posts 

### User Controller
These were created to do user blocking operations
- User/Block-> to block another user
- User/RemoveBlock-> to unblock another user
- User/BlockedUsers-> to see blocked users

### WebApi Controller
These were created to communicate with the Openlibrary book API.
- WebApi/Search->to search book or author from Openlibrary API
- WebApi/SearchResult-> to see search result from Openlibrary API
- WebApi/AddPostFromApi-> to add api search result as post
- WebApi/GetPostFromApi->to see added api search result as post

## Logging
Middleware added for logging. This middleware will add a record to the Log table in the database every time a request is made on the page. Log records are kept in PostgreSql, so a new dbcontext has been added. Id, TraceIdentifier, ResponseStatusCode, RequestMethod, RequestPath, RoutePath, IpAddress are added to table as columns. It gets this data from HttpContext. Logging can be found in GaripSozluk.Business.Middlewares.LoggingMiddleware. 
### Log Controller
Log controller is used for seeing all logs in the database. These log files can be sorted by columns or filtering with any keywords. You can also get most requested top 10 records.
- Log/Index->to see logs

## HealthCheck
Healthcheck UI implemented to project for checking DbContext and SqlServer health. Our own health checker classes inherited from IHealthCheck was created which can be found in folder GaripSozluk.Data.HealthChecks.
- HealthCheck: /healthcheck
- HealthCheck UI: /healthchecks-ui
![alt text](https://i.imgur.com/0MlXdZu.png)

## Hangfire
Hangfire implemented to project for performing recurring tasks. A job has been created to work 1 time a day. It is triggered within the Api project and opens post for every time it is run. There are two recurring jobs. First one has been prepared to display the previous day's log records as entry. Second one has been prepared to display most requested log records from previous da as entry. For doing related operations, some methods were created in the post service in the WebApp, but these methods were triggered as recurring jobs in startup of Api.
![alt text](https://i.imgur.com/aKddm8f.png)
