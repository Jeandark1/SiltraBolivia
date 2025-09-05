

 ## Para crear una migración:
    dotnet ef migrations add InitialCreate --project CargoApi.Infrastructure --startup-project CargoApi.Presentation --output-dir Migrations

 ## Para aplicar migraciones:
    dotnet ef database update --project CargoApi.Infrastructure --startup-project CargoApi.Presentation

 ## Para generar script SQL:
    dotnet ef migrations script --project CargoApi.Infrastructure --startup-project CargoApi.Presentation --output migrations.sql

 ## Eliminar todas las migraciones  (ver actual)
    dotnet ef migrations remove -p .\CargoApi.Infrastructure\CargoApi.Infrastructure.csproj -s .\CargoApi.Presentation\CargoApi.Presentation.csproj

  ## este si funciona crear migracion
     dotnet ef migrations add InitialCreate -p .\CargoApi.Infrastructure\CargoApi.Infrastructure.csproj -s .\CargoApi.Presentation\CargoApi.Presentation.csproj -o Data\Migrations

  ## si funciona para eliminacion de migraciones en solution
    dotnet ef migrations remove -p .\CargoApi.Infrastructure\CargoApi.Infrastructure.csproj -s .\CargoApi.Presentation\CargoApi.Presentation.csproj

  ## Eliminar la base de datos manualmente o con:
    dotnet ef database drop -p .\CargoApi.Infrastructure\CargoApi.Infrastructure.csproj -s .\CargoApi.Presentation\CargoApi.Presentation.csproj

  ## en console nugget

crear migracion en 
add-migration init 

actualizar 
update-database

eliminar base de datos 
drop-database
