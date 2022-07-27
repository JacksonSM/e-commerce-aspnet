﻿using AspStore.Application.Interfaces.AppService;
using AspStore.Application.Mappings;
using AspStore.Application.Services;
using AutoMapper;
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

            return services;
        }
    }
}
