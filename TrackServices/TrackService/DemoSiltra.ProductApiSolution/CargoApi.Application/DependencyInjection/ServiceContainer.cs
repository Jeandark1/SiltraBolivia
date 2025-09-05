

using Microsoft.Extensions.DependencyInjection;

namespace CargoApi.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            return services;
        }
    }
}
