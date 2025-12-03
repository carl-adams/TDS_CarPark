# TDS_CarPark API

.NET Take Home Assessment - Thank you for taking the time to review this.

## Description

This is a small API project created to manage a car park system.
It contains 3 endpoints, which focus on checking availability, taking a space, and exiting from the space.
These endpoints are the following:
* GET /availability - returns the number of available spaces in the car park.
* POST /parking - takes a parking space if available.
* POST /parking/exit - exits from a parking space and returns the total cost of the stay.

The costs of the stay are calculated based on 3 vehicle types, per minute of the stay. A type must be stated on taking a parking space. Additionally, further 
charges are added every 5 minutes regardless of vehicle type.

## Getting Started

### Dependencies

* This has been created with .NET10 and using an MSSQL database.
* Please create a database in your preferred location/server.
* I have used the following connection names but feel free to change these in the appsettings.json file:
  * LocalDB server name: (localdb)\MSSQLLocalDB
  * Database name: TDSCarPark
* This project uses Entity Framework Core and also includes Swagger for API documentation/ease of testing endpoints.

### Installing

Once downloading/cloning from the main branch, please open in visual studio or your preferred IDE.

#### Database Setup

* In regard to the database, migration/seed files have been created prior and included in the repository for quicker/easier setup.
* Please run the following commands within the Package Manager Console to create the relevant tables and seed with data:
```
update-database
```

#### API Project Setup

* Within TDS_CarPark.API project, the launchSettings.json file has been pre-configured to launch the API and Swagger UI on running the project.
* dotnet run will also launch the project and Swagger UI if preferred.
* The swagger UI should be accessed via /swagger where each endpoint can be tested directly using the "Try it out" feature.
* Relevant schemas are detailed within the Swagger UI for reference.

#### Testing Setup
* A separate test project has been created within the solution, TDS_CarPark.Tests. This contains only a controller example currently, however this can be expanded upon as needed.
* The controller contains two test examples based on the /parking/exit endpoint.
* To run the tests, please use the Test Explorer within Visual Studio or your preferred IDE.
* Alternatively, the following command can be used within the terminal:
```
dotnet test
```

### Further Notes/Assumptions

* .NET 10 was used as it is the latest LTS, hope this isn't a problem as it is fairly new.
* I typically use MSSQL Management Studio for database management, so LocalDB was used for simplicity.
* Though the migration & seed files included in a repository may not be best practice, I wanted to create a quick and easy setup for review purposes.
* In regard to car park spaces, I have just set this to 9 spaces, but hope this provides enough demonstration.
* The additional charge per 5 minutes is currently static and not handled via the database, but this can be easily modified if needed.
* You may notice there is no validation on the format of the VehicleReg at this time, but could be applied. It does include space removal to prevent user error between parking and exiting.
