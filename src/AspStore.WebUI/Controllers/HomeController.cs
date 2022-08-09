using AspStore.Application.Interfaces.AppService;
using AspStore.WebUI.Extensions.Helpers;
using AspStore.WebUI.Extensions.Identity;
using AspStore.WebUI.Infra;
using AspStore.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _serviceProduto;
        private readonly ICategoriaAppService _serviceCategoria;
        private readonly IGerenciadorImagens _gerirImagens;
        private readonly IFiltragemCatalago _filtrarCatalago;
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel IndexModel { get; set; } = new IndexModel();

        public HomeController(
            IProdutoAppService serviceProduto, 
            ICategoriaAppService serviceCategoria,
            IGerenciadorImagens gerirImagens, 
            IFiltragemCatalago filtrarCatalago)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
            _gerirImagens = gerirImagens;
            _filtrarCatalago = filtrarCatalago;
        }

        public async Task<IActionResult> Index(int? categoriaSelecionada, int? precoMinimo, int? precoMaximo, string pesquisa)
        {

            IndexModel.Catalogo = _filtrarCatalago.AplicarFiltro(categoriaSelecionada, precoMinimo, precoMaximo, pesquisa);

            IndexModel.Categorias = await _serviceCategoria.SelecionarTodos();
            ViewBag.Categorias = new SelectList(IndexModel.Categorias, "Id", "Nome");

            return View(IndexModel);
        }

        public IActionResult Contato()
        {
            ViewData["Email"] = "aspstorecontato@gmail.com";
            ViewData["Telefone"] = "(83) 99859-2563";
            ViewData["Endereco"] = "Rua Americo, 36";

            return View();
        }
        public IActionResult SobreNos()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EnviarEmail(string nome, string email, string mensagem)
        {


            return RedirectToAction(nameof(Contato));
        }
        public async Task<IActionResult> PaginaProduto(int produtoId)
        {
            IndexModel.ProdutoVM = await _serviceProduto.ObterProdutoComCategoria(produtoId);
            ViewData["listaImagens"] = _gerirImagens.BuscarImagensProduto(IndexModel.ProdutoVM.CodigoInterno);

            return View(IndexModel);
        }
        public async Task<IActionResult> AdicionarAoCarrinho(int produtoId)
        {

            return RedirectToAction("Index");
        }
    }
}
