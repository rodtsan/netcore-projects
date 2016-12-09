dotnet ef migrations add InitialIdentityCreate -c ApplicationIdentityDbContext
dotnet ef database update -c ApplicationIdentityDbContext
dotnet ef migrations remove