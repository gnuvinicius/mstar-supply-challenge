using MStarSupply.Repository.Repositories;
using MStarSupply.Services.Services;

namespace MStarSupplyApi.Extensions
{
    internal static class DependenciesInjectionExtension
    {
        internal static IServiceCollection ResolveDependences(this IServiceCollection services)
        {
            services.AddScoped<IMercadoriaService, MercadoriaService>();
            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();

            return services;
        }
    }
}
