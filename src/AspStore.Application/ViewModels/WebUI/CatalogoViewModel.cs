using System.Collections.Generic;

namespace AspStore.Application.ViewModels.WebUI
{
    public class CatalogoViewModel
    {
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public CategoriaViewModel Categoria { get; set; } = new CategoriaViewModel();

    }
}
