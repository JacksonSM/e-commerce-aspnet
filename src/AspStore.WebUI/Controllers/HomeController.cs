using AspStore.Application.Interfaces.AppService;
using AspStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _serviceProduto;
        private readonly ICategoriaAppService _serviceCategoria;

        public HomeController(IProdutoAppService serviceProduto, ICategoriaAppService serviceCategoria)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _serviceProduto.SelecionarTodos();
            return View(produtos);
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
        public IActionResult EnviarEmail(string nome, string email, string mensagem )
        {


            return RedirectToAction(nameof(Contato));
        }

    }
}
