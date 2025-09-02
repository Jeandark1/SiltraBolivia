using Microsoft.Extensions.DependencyInjection;

namespace CargoApi.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services) 
        {
            return services;
        }
    }
}
