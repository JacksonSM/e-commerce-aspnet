using AspStore.Application.Interfaces.AppService;
using AspStore.Application.Interfaces.AppService.ConjutoCarrinho;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Application.ViewModels.WebUI;
using AspStore.Domain.Interfaces;
using AspStore.WebUI.Extensions.Helpers;
using AspStore.WebUI.Extensions.Identity;
using AspStore.WebUI.Infra;
using AspStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICarrinhoAppService _serviceCarrrinho;
        private readonly IClienteAppService _serviceCliente;

        private readonly IGerenciadorImagens _gerirImagens;
        private readonly IFiltragemCatalago _filtrarCatalago;
        private readonly IUserInContext _user;

        public IndexModel IndexModel { get; set; } = new IndexModel();

        public HomeController(
            IProdutoAppService serviceProduto,
            ICategoriaAppService serviceCategoria,
            IGerenciadorImagens gerirImagens,
            IFiltragemCatalago filtrarCatalago,
            IUserInContext user,
            ICarrinhoAppService serviceCarrrinho,
            IClienteAppService serviceCliente)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
            _serviceCarrrinho = serviceCarrrinho;
            _serviceCliente = serviceCliente;
            _gerirImagens = gerirImagens;
            _filtrarCatalago = filtrarCatalago;
            _user = user;

            IndexModel.Catalogo = new CatalogoViewModel();
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
            ViewBag.Categorias = new SelectList(IndexModel.Categorias, "Id", "Nome");
            return View(IndexModel);
        }
        public IActionResult SobreNos()
        {
            ViewBag.Categorias = new SelectList(IndexModel.Categorias, "Id", "Nome");
            return View(IndexModel);
        }
        [Authorize]
        public async Task<IActionResult> Carrinho()
        {
            ViewBag.Categorias = new SelectList(IndexModel.Categorias, "Id", "Nome");
            IndexModel.Carrinho = await _serviceCarrrinho.ObterCarrinhoComProduto(_user.GetCPF());
            return View(IndexModel);
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

        [Authorize]
        public async Task<IActionResult> AdicionarAoCarrinho(int produtoId)
        {
            var cpf = _user.GetCPF();
            var cliente = await _serviceCliente.ObterClienteComCarrinho(cpf);
            var produtoVM = await _serviceProduto.SelecionarPorId(produtoId);
            var produtoCarrinho = new ProdutoCarrinhoViewModel(cliente.Carrinho.Id.Value, produtoVM);
            await _serviceCarrrinho.SalvarProdutoNoCarrinho(cliente, produtoCarrinho);
            await _serviceCarrrinho.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
