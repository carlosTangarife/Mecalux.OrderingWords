using Mecalux.OrderingWords.Application.Contracts.Service;
using Microsoft.Extensions.DependencyInjection;
using Mecalux.OrderingWords.Application.Services;

namespace Mecalux.OrderingWords.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderWordsService, OrderWordsService>();
            services.AddScoped<IOrderWordsStrategy, OrderWordsStrategy>();
            services.AddScoped<IOrderWordsOptions, OrderWordsAlphabeticAsc>();

            return services;
        }
    }
}
