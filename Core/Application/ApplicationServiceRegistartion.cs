using BusStation_API.Core.Application.SieveConfig;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistartion
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            
            services.AddScoped<ISieveProcessor, CustomSieveConfiguration>();
            return services;
        }
    }
}
