1. dotnet add package Npgsql
2. dotnet add package Npgsql.EntityframeworkCore.PostgreSQL
3. dotnet add package EFCore.NamingConventions
4. dotnet tool install --global dotnet-ef
5. dotnet add package Microsoft.EntityframeworkCore.Design
# ***
6. dotnet ef migrations add InitialMigration
7. dotnet ef database update
# ***
8. dotnet add package GraphQl --version 2.4.0
9. dotnet add package GraphQl.Server.Transports.AspNetCore --version 3.4.0
10. dotnet add package GraphQl.Server.Transports.webSockets --version 3.4.0
11. dotnet add package GraphQl.Server.Ui.Playground

**Se logea el tiempo con fecha de calendario**

12. ng add apollo-angular o npm install apollo-angular @apollo/client graphql