using AspStore.WebUI.Extensions.Helpers;
using AspStore.WebUI.Infra;
using AspStore.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class CarrosselBOController : Controller
    {
        private readonly IUnitOfUpload _carregarImagem;
        private readonly IManipuladorArquivoCSVCarrossel _manipuladorCarrossel;

        public CarrosselBOController(IUnitOfUpload carregarImagem, IManipuladorArquivoCSVCarrossel manipuladorCarrossel)
        {
            _carregarImagem = carregarImagem;
            _manipuladorCarrossel = manipuladorCarrossel;
        }

        [Route("/BackOffice/Carrossel")]
        public IActionResult Index()
        {
            return View(_manipuladorCarrossel.ObterCarrossel().Result);
        }
        [Route("/BackOffice/Carrossel/Create")]

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/Carrossel/Create")]
        public async Task<IActionResult> Create(IFormFile imagem, ItemCarrossel itemCarrossel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _manipuladorCarrossel.GravarItemCarrossel(itemCarrossel);
                    _carregarImagem.CarregarImagemCarrossel(imagem, itemCarrossel.Ordem.ToString());
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Route("/BackOffice/Carrossel/Edit")]
        public IActionResult Edit(int ordem)
        {
            var carrossel = _manipuladorCarrossel.ObterCarrossel().Result;

            return View(carrossel.FirstOrDefault(i => i.Ordem == ordem));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/Carrossel/Edit")]
        public async Task<IActionResult> Edit(IFormFile imagem, ItemCarrossel itemCarrossel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _manipuladorCarrossel.GravarItemCarrossel(itemCarrossel);
                    if(imagem != null) _carregarImagem.CarregarImagemCarrossel(imagem, itemCarrossel.Ordem.ToString());
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
