using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels.WebUI;
using System.Linq;

namespace AspStore.WebUI.Extensions.Helpers
{
    public class FiltragemCatalago : IFiltragemCatalago
    {
        private readonly IProdutoAppService _serviceProduto;

        public FiltragemCatalago(IProdutoAppService serviceProduto)
        {
            _serviceProduto = serviceProduto;
        }

        public  CatalogoViewModel AplicarFiltro(int? categoriaAplicada,int? precoMinimo,int? precoMaximo, string pesquisa)
        {

            CatalogoViewModel catalogo = new CatalogoViewModel();
            catalogo.CategoriaAplicada = categoriaAplicada;

            catalogo.ProdutosVM = _serviceProduto.SelecionarTodos().Result;

            if (categoriaAplicada != null) 
            {
                catalogo.ProdutosVM = catalogo.ProdutosVM.Where(p => p.CategoriaId == categoriaAplicada);

            }


            if(precoMinimo != null && precoMaximo == null)
            {
                catalogo.ProdutosVM = catalogo.ProdutosVM.Where(p => p.Preco <= precoMinimo); 
                catalogo.PrecoMinimo = precoMinimo; 
            }
            else if (precoMaximo != null && precoMinimo == null)
            {
                catalogo.ProdutosVM = catalogo.ProdutosVM.Where(p => p.Preco <= precoMinimo);
                catalogo.PrecoMaximo = precoMaximo; 
            }
            else if(precoMinimo != null && precoMaximo != null)    
            {
                catalogo.ProdutosVM = catalogo.ProdutosVM.Where(p => p.Preco >= precoMinimo && p.Preco <= precoMaximo); 
                catalogo.PrecoMinimo= precoMinimo;
                catalogo.PrecoMaximo = precoMaximo;
            }

            if (!string.IsNullOrEmpty(pesquisa))
            {
                catalogo.Pesquisa = pesquisa;
                catalogo.ProdutosVM = catalogo.ProdutosVM.Where(p => p.Nome.ToUpper().Contains(pesquisa.ToUpper()));
            }


            catalogo.EstaFiltrada = true;

            return catalogo;
        }
    }
}