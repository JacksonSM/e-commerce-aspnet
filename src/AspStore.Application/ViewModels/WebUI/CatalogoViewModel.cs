using AspStore.Application.Interfaces.AppService;
using System.Collections.Generic;

namespace AspStore.Application.ViewModels.WebUI
{
    public class CatalogoViewModel
    {
        public IEnumerable<ProdutoViewModel> ProdutosVM { get; set; }
        public CategoriaViewModel CategoriaVM { get; set; }
        public int? CategoriaAplicada { get; set; }
        public decimal? PrecoMinimo { get; set; }
        public decimal? PrecoMaximo { get; set; }

        public bool EstaFiltrada { get; set; }
    }
}
