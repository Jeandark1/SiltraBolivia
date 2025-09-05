using CargoApi.Infrastructure.Data;
using CargoApi.Infrastructure.Repositories;
using CargoApi.Infrastructure.Filters;
using CargoApi.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CargoApi.Infrastructure.Services;
using CargoApi.Application.Interfaces.Services;
using CargoApi.Application.Interfaces.Repositories;
using CargoApi.Domain.Interfaces.Services;

namespace CargoApi.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // DataBase context coneccion a la base de datos

            /*services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));*/


            var databaseProvider = configuration["DatabaseProvider"] ?? "SqlServer";
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                switch (databaseProvider)
                {
                    case "SqlServer":
                    default:
                        options.UseSqlServer(connectionString,
                            sqlOptions => sqlOptions.EnableRetryOnFailure());
                        break;
                }
            });

            // HttpContext Accessor
            services.AddHttpContextAccessor();

            // Services
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            /*
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();*/

            // e.g., services.AddTransient<IMyService, MyService>();

            // Services

            /*
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileStorageService, FileStorageService>();*/

            // Filters
            // services.AddScoped<ValidationFilter>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            // Apply migrations
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                // Seed data if needed
                // var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
                // seeder.SeedAsync().Wait();
            }

            // Middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }


    }
}
