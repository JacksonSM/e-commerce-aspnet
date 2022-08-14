using AspStore.WebUI.Models;
using AspStore.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspStore.WebUI.Controllers
{
    public class ContatoBOController : Controller
    {
        private readonly IContatoService _contatoService;

        public ContatoBOController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public ActionResult PaginaContatoBO()
        {
            var contato = _contatoService.ObterContato();   
            return View(contato);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaginaContatoBO(ContatoModel contatoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoService.SalvarContato(contatoModel);
                }
                return RedirectToAction(nameof(PaginaContatoBO));
            }
            catch
            {
                return View();
            }
        }
    }
}
