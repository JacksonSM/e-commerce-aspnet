using AspStore.Application.Interfaces.AppService;
using AspStore.WebUI.Infra;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class CatalagoController : Controller
    {
        private readonly IGerenciadorImagens _gerirImagens;
        private readonly IProdutoAppService _serviceProduto;

        public CatalagoController(IProdutoAppService serviceProduto, IGerenciadorImagens gerirImagens)
        {
            _serviceProduto = serviceProduto;
            _gerirImagens = gerirImagens;
        }

        public async Task<IActionResult> Pagina(int categoriaId)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(categoriaId);
            ViewData["listaImagens"] = _gerirImagens.BuscarImagensProduto(produtoVM.CodigoInterno);

            return View(produtoVM);
        }
    }
}
