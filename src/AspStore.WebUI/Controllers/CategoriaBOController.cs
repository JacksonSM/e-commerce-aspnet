using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.WebUI.Controllers
{
    public class CategoriaBOController : Controller
    {
        private readonly ICategoriaAppService _serviceCategoria;

        public CategoriaBOController(ICategoriaAppService serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
        }
        [Route("/BackOffice/CategoriaBO")]
        public async Task<ActionResult> Index()
        {
            var categorias = await _serviceCategoria.SelecionarTodos();
            return View(categorias);
        }
        [Route("/BackOffice/CategoriaBO/Details/")]
        public async Task<ActionResult> Details(int id)
        {
            var categoria = await _serviceCategoria.SelecionarPorId(id);
            return View(categoria);
        }

        [Route("/BackOffice/CategoriaBO/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/CategoriaBO/Create")]
        public async Task<ActionResult> Create(CategoriaViewModel categoriaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceCategoria.Adicionar(categoriaVM);
                    await _serviceCategoria.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/BackOffice/CategoriaBO/Edit/")]
        public async Task<ActionResult> Edit(int id)
        {

            var categoria = await _serviceCategoria.SelecionarPorId(id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/CategoriaBO/Edit/")]
        public async Task<ActionResult> Edit(CategoriaViewModel categoriaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceCategoria.Atualizar(categoriaVM);
                    await _serviceCategoria.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/BackOffice/CategoriaBO/Delete/")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _serviceCategoria.SelecionarPorId(id);
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("/BackOffice/CategoriaBO/Delete/")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceCategoria.ExcluirPorId(id);
                await _serviceCategoria.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
