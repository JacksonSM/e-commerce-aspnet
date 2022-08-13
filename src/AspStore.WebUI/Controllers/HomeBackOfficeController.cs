using Microsoft.AspNetCore.Mvc;

namespace AspStore.WebUI.Controllers
{
    public class HomeBackOfficeController : Controller
    {
        [Route("/BackOffice")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carrossel()
        {
            return View();
        }
    }
}
