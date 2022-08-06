using AspStore.Application.ViewModels.WebUI;

namespace AspStore.WebUI.Extensions.Helpers
{
    public interface IFiltragemCatalago
    {
        CatalogoViewModel AplicarFiltro(int? categoriaAplicada, int? precoMinimo, int? precoMaximo);
    }
}
