using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels.WebUI;

namespace AspStore.WebUI.Extensions.Helpers
{
    public class FiltragemCatalago : IFiltragemCatalago
    {
        private readonly IProdutoAppService _serviceProduto;

        public FiltragemCatalago(IProdutoAppService serviceProduto)
        {
            _serviceProduto = serviceProduto;
        }

        public  CatalogoViewModel AplicarFiltro(int? categoriaAplicada)
        {
            CatalogoViewModel catalogo = new CatalogoViewModel();

            if (categoriaAplicada == null || categoriaAplicada == 0) 
            {
                catalogo.ProdutosVM = _serviceProduto.SelecionarTodos().Result;
                return catalogo;
            }

            catalogo.ProdutosVM = _serviceProduto.SelecionarTodos(p => p.CategoriaId == categoriaAplicada).Result;
            catalogo.EstaFiltrada = true;

            return catalogo;
        }
    }
}