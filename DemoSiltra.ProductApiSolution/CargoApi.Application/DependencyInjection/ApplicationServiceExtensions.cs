using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CargoApi.Application.Interfaces.Services;
using CargoApi.Application.Services;
using System.Reflection;
using AutoMapper;


namespace CargoApi.Application.DependencyInjection
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {

            // Servicios de aplicación  
            services.AddScoped<IUserService, UserService>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           

            //linea

            /* services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IVehicleService, VehicleService>();
            */

            //AutoMapper - asegurémonos de configurarlo correctamente

            /* services.AddAutoMapper(typeof(ApplicationServiceExtensions).Assembly);

             services.AddAutoMapper(typeof(UserMappingProfile));
             services.AddAutoMapper(typeof(DriverMappingProfile));
             services.AddAutoMapper(typeof(CompanyMappingProfile));*/

            return services;
        }
    }
}
