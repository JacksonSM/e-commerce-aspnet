using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.WebUI;
using System.Collections.Generic;

namespace AspStore.WebUI.Models
{
    public class IndexModel
    {
        public CatalogoViewModel Catalogo { get; set; } = new CatalogoViewModel();
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
        public ProdutoViewModel ProdutoVM { get; set; }
    }
}
