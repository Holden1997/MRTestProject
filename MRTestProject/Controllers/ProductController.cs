using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MRTestProject.Domain;
using MRTestProject.Extensions;
using MRTestProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRTestProject.Common;
using System.Linq;

namespace MRTestProject.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IStoreService _storeService;
        public ProductController(IStoreService storeService)
        {
            _storeService = storeService;          
        }
        // GET: Product
        public ActionResult Index(string filter, int? limit, int? offset)
        {
            var products = _storeService.GetProducts(limit, offset).MapToViewModel();

            BaseViewModel baseViewModel = new BaseViewModel();

            if (filter != null)
            {
                baseViewModel.Products = products.Where(_ =>
                {
                    if (_.Description == null)
                        return _.Name.StartsWith(filter)
                        || _.Price.ToString().StartsWith(filter)
                        || _.Category.Name.StartsWith(filter);
                   
                    else
                        return _.Name.StartsWith(filter)
                        || _.Price.ToString().StartsWith(filter)
                        || _.Category.Name.StartsWith(filter)
                        || _.Description.StartsWith(filter);
                });
            }

            else baseViewModel.Products = products;

            return View(baseViewModel);
        }
      
        // GET: Product/Create
        public ActionResult Create()
        {
            var categories = _storeService.GetCategories();
            
            var baseModel = MapToBaseViewModel(categories,new ProductViewModel());

            return View(baseModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BaseViewModel collection)
        {
            
            try
            {
                _storeService.CreateProduct(collection.MapToDomainModel());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid id)
        {
            var categories = _storeService.GetCategories();
            var productViewModel = _storeService.GetProduct(id).MapToViewModel();

            var baseModel = MapToBaseViewModel(categories, productViewModel);

            return View(baseModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BaseViewModel baseModel)
        {
            try
            {
                _storeService.EditProduct(baseModel.MapToDomainModel());

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
            Product product = new Product();
            product.ProductId = id;

            _storeService.Delete(product);

            return RedirectToAction(nameof(Index));
        }
        private BaseViewModel MapToBaseViewModel(IList<Category> categories, ProductViewModel productViewModel)
        {
            BaseViewModel baseView = new BaseViewModel();
            baseView.Categories = new List<SelectListItem>();

            foreach (var category in categories)
                baseView.Categories.Add(new SelectListItem { Text = category.Name, Value = category.CategoryId.ToString() });

            baseView.Product = productViewModel;

            return baseView;
        }

    }
}