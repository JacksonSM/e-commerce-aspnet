using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.WebUI.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AspStore.BackOffice.WebUI.Controllers
{
    public class ProdutoBOController : Controller
    {
        private readonly IGerenciadorImagens _gerirImagens;

        private readonly IProdutoAppService _serviceProduto;
        private readonly ICategoriaAppService _serviceCategoria;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProdutoBOController(IProdutoAppService serviceProduto, ICategoriaAppService serviceCategoria,
            IGerenciadorImagens gerenciadorImagens, IWebHostEnvironment webHostEnvironment)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
            _gerirImagens = gerenciadorImagens;
            _webHostEnvironment = webHostEnvironment;
        }




        [Route("/BackOffice/ProdutoBO")]
        public IActionResult Index()
        {
            var listProdutos = _serviceProduto.TodosProdutoComCategoria().Result;
            return View(listProdutos);
        }

        [Route("/BackOffice/ProdutoBO/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(id);
            if (produtoVM is null) return NotFound();
             
            ViewData["listaImagens"] =  _gerirImagens.BuscarImagensProduto(produtoVM.CodigoInterno);


            return View(produtoVM);
        }

        [Route("/BackOffice/ProdutoBO/create")]
        public async Task<IActionResult> Create()
        
        {
            ViewBag.Categorias = new SelectList(await _serviceCategoria.SelecionarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/ProdutoBO/create")]
        public async Task<IActionResult> Create(IFormFile imagemPrincipal, IFormFileCollection imagensSegundaria,
            ProdutoViewModel produtoVM)
        {
     

            try
            {
                if (ModelState.IsValid)
                {
                    produtoVM.CodigoInterno =  _serviceProduto.GerarCodigoInterno().Result;

                    await _serviceProduto.Adicionar(produtoVM);
                    await _serviceProduto.SaveAsync();

                    if (imagemPrincipal is not null) 
                        _gerirImagens.SalvarImagemPrincipal(imagemPrincipal, produtoVM.CodigoInterno);
                    if (imagensSegundaria.Count > 0)
                        _gerirImagens.SalvarImagens(imagensSegundaria, produtoVM.CodigoInterno);


                }
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return View();
            }
        }

        [Route("/BackOffice/ProdutoBO/Edit/")]
        public async Task<ActionResult> Edit(int id)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(id);
            if (produtoVM is null) return NotFound();
            ViewData["listaImagens"] = _gerirImagens.BuscarImagensProduto(produtoVM.CodigoInterno);
            ViewBag.Categorias = new SelectList(await _serviceCategoria.SelecionarTodos(), "Id", "Nome");

            return View(produtoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/ProdutoBO/Edit/")]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoVM,IFormFile imagemPrincipal, IFormFileCollection imagensSegundaria)
        {
            try
            {
                await _serviceProduto.Atualizar(produtoVM);
                if (imagemPrincipal is not null)
                    _gerirImagens.SalvarImagemPrincipal(imagemPrincipal, produtoVM.CodigoInterno);
                if (imagensSegundaria.Count > 0)
                    _gerirImagens.SalvarImagens(imagensSegundaria, produtoVM.CodigoInterno);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/BackOffice/ProdutoBO/Delete/")]
        public async Task<ActionResult> Delete(int id)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(id);
            if (produtoVM is null) return NotFound();

            return View(produtoVM);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        [Route("/BackOffice/ProdutoBO/Delete/")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceProduto.ExcluirPorId(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> ExcluirImagem(string nomeImagem, int idProduto)
        {
            _gerirImagens.ExcluirImagem(nomeImagem);
            return RedirectToAction("Edit", new { id = idProduto});
        }
    }

    
}
