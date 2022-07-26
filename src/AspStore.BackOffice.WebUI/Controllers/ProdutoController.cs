﻿using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.BackOffice.WebUI.Infra;
using AspStore.BackOffice.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AspStore.BackOffice.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IUnitOfUpload _unitOfUpload;

        private readonly IProdutoAppService _serviceProduto;
        private readonly ICategoriaAppService _serviceCategoria;

        public ProdutoController(IProdutoAppService serviceProduto, ICategoriaAppService serviceCategoria, IUnitOfUpload unitOfUpload)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
            _unitOfUpload = unitOfUpload;
        }



        // GET: ProdutoController
        public IActionResult Index()
        {
            
            return View();
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(await _serviceCategoria.SelecionarTodos(), "Id", "Nome");
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,ProdutoImagemModel produtoImagemModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfUpload.UploadImage(file);

                    var imag = produtoImagemModel.ImagemModel;
                    imag.Nome = file != null ? file.FileName : "";

                    await _serviceProduto.Adicionar(produtoImagemModel.ProdutoVM);
                    await _serviceProduto.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
