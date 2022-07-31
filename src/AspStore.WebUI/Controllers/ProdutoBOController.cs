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

        // GET: ProdutoController/Details/5
        [Route("/BackOffice/ProdutoBO/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(id);
            if (produtoVM is null) return NotFound();
             
            ViewData["listaImagens"] =  _gerirImagens.BuscarImagensProduto(produtoVM.CodigoInterno);


            return View(produtoVM);
        }

        // GET: ProdutoController/Create
        [Route("/BackOffice/ProdutoBO/create")]
        public async Task<IActionResult> Create()
        
        {
            ViewBag.Categorias = new SelectList(await _serviceCategoria.SelecionarTodos(), "Id", "Nome");
            return View();
        }

        // POST: ProdutoController/Create
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

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var produtoVM = await _serviceProduto.ObterProdutoComCategoria(id);
            if (produtoVM is null) return NotFound();

            return View(produtoVM);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
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
     
    }
}
