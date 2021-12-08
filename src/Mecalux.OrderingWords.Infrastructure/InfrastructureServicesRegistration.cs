using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Mecalux.OrderingWords.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServicesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IOrderOptionsRepository, OrderOptionsRepository>();

            return services;
        }
    }
}
