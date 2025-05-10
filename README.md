## How to run the project

You will execute the program, and it will open in Swagger. You should remove '/swagger' from the URL, or you can directly use http://localhost:5142/index.html or https://localhost:7268/index.html to view the Todo List screen.

## Any setup requirements	

The .Net version uses for this project is 8.0.2

Install these packages:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
Or, if you prefer this approach:
1. Open the TodoApi.csproj file in a text editor or Microsoft Visual Studio. This file contains the project's configuration.
2. Add the following PackageReference to the <ItemGroup> element to include Entity Framework Core for in-memory databases. 
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
</ItemGroup>


## Completed Functionality

The following core features have been implemented:

* CRUD operations for todos.
* Listing and filtering of todos by status.
* Marking todos as complete.
* Basic input validation (title, due date).
* Responsive user interface with Bootstrap.

## Challenges Encountered

During development, the following challenges were faced:

* Setting up Entity Framework Core and database migrations.
* Implementing robust error handling in the API and frontend.
* Ensuring consistent data validation between the client and server.
* Troubleshooting  `fetch`  API calls and handling asynchronous operations.
* Connect the index screen with the application.

## Future Enhancements

The following enhancements are planned for future development:

* Additional filtering options (e.g., by priority, date range).
* Sorting of todos (e.g., by due date, priority).
* API documentation (e.g., using Swagger).
