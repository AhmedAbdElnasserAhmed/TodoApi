o	How to run the project
You will execute the program, and it will open in Swagger. You should remove '/swagger' from the URL, or you can directly use http://localhost:5142/index.html or https://localhost:7268/index.html to view the Todo List screen.

o	Any setup requirementsThe .Net version uses for this project is 8.0.2
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

