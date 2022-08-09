using AspStore.CrossCutting.Helpers;
using AspStore.Domain.Interfaces;
using AspStore.Domain.Interfaces.Services;
using AspStore.Domain.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AspStore.CrossCutting
{
    public static class DependencyInjectionDomain
    {

        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddScoped<IProdutoDomainService, ProdutoDomainService>();
            services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();
            services.AddScoped<IClienteDomainService, ClienteDomainService>();


            return services;
        }
    }
}
