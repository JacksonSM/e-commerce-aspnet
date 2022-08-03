using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.WebUI.Infra;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IGerenciadorImagens _gerirImagens;
        private readonly IProdutoAppService _serviceProduto;

        public ProdutoController(IProdutoAppService serviceProduto, IGerenciadorImagens gerirImagens)
        {
            _serviceProduto = serviceProduto;
            _gerirImagens = gerirImagens;
        }

        public async Task<IActionResult> PaginaProduto(int produtoId)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(produtoId);
            ViewData["listaImagens"] = _gerirImagens.BuscarImagensProduto(produtoVM.CodigoInterno);

            return View(produtoVM);
        }
    }
}
