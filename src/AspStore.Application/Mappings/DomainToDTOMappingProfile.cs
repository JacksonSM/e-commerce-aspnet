using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Entities;
using AutoMapper;

namespace AspStore.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {

        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<ProdutoPedido, ProdutoPedidoViewModel>().ReverseMap();


            CreateMap<Carrinho, CarrinhoViewModel>().ReverseMap();
            CreateMap<ProdutoCarrinho, ProdutoCarrinhoViewModel>().ReverseMap();
            CreateMap<Imagem, ImagemViewModel>().ReverseMap();

        }

    }
}
