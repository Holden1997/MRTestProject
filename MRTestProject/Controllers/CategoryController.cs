using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRTestProject.Common;
using MRTestProject.Domain;
using MRTestProject.Extensions;
using MRTestProject.Models;

namespace MRTestProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IStoreService _storeService;
        public CategoryController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _storeService.GetCategories().MapToViewModel();

            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
        
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                _storeService.CreateCategory(categoryViewModel.MapToDomainModel());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid CategoryId)
        {
            var category = _storeService.GetCategory(CategoryId).MapToViewModel();

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            try
            {  
                _storeService.EditCategory(categoryViewModel.MapToDomainModel());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            
            _storeService.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }

    }
}