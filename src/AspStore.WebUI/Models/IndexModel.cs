using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Application.ViewModels.WebUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspStore.WebUI.Models
{
    public class IndexModel
    {
        public CatalogoViewModel Catalogo { get; set; } 
        public CarrinhoViewModel Carrinho { get; set; } 
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
        public ProdutoViewModel ProdutoVM { get; set; }

        public bool CatalogoEstaFiltrado()
        {
            return Catalogo.EstaFiltrada;
        }
    }
}
