﻿using AspStore.Application.Interfaces.AppService;
using AspStore.Application.Interfaces.AppService.ConjutoCarrinho;
using AspStore.Application.Mappings;
using AspStore.Application.Services;
using AspStore.Application.Services.AppService;
using AspStore.Application.Services.ConjutoCarrinho;
using Microsoft.Extensions.DependencyInjection;


namespace AspStore.CrossCutting
{
    public static class DependencyInjectionApplication
    {

        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<ICarrinhoAppService, CarrinhoAppService>();

            return services;
        }
    }
}
