using AspStore.Domain.Interfaces.Repository;
using AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Infra.Data.ORM;
using AspStore.Infra.Data.Repository;
using AspStore.Infra.Data.Repository.ConjuntoCarrinho;
using AspStore.Infra.Data.Repository.ConjuntoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspStore.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IProdutoCarrinhoRepository, ProdutoCarrinhoRepository>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoPedidoRepository, ProdutoPedidoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            return services;
        }
        public static IServiceCollection AddDbContextService(this IServiceCollection services,
                                                                       IConfiguration configuration)
        {
            services.AddDbContext<AspStoreDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
