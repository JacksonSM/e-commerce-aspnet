using AspStore.Domain.Interfaces.Services;
using AspStore.Domain.Interfaces.Services.ConjutoCarrinho;
using AspStore.Domain.Services;
using AspStore.Domain.Services.ConjutoCarrinho;
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
            services.AddScoped<ICarrinhoDomainService, CarrinhoDomainService>();


            return services;
        }
    }
}
