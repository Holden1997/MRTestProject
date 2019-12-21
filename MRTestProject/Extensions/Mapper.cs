using MRTestProject.Common;
using MRTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRTestProject.Extensions
{
    public static class Mapper
    {
        public static IList<CategoryViewModel> MapToViewModel(this IList<Category> categories)
        {

           var categoriesViewModel = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                categoriesViewModel.Add(new CategoryViewModel
                {
                    CategoryId = item.CategoryId,
                    Name = item.Name
                });
            }
            return categoriesViewModel;
        }
        public static CategoryViewModel MapToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name 
            };
        }
        public static Category MapToDomainModel(this CategoryViewModel categoryViewModel)
        {
            return new Category
            {
                CategoryId = categoryViewModel.CategoryId,
                Name = categoryViewModel.Name
            };
        }

        public static Product MapToDomainModel(this BaseViewModel baseViewModel)
        {
            Product product = new Product();
            product.CategoryId =  baseViewModel.CategoryId ;
            product.ProductId = baseViewModel.Product.ProductId;
            product.Price = baseViewModel.Product.Price;
            product.Name = baseViewModel.Product.Name;
            product.Description = baseViewModel.Product.Description;

            return product;
        }

        public static IList<ProductViewModel> MapToViewModel(this IList<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
                productsViewModel.Add(new ProductViewModel { Name = product.Name, Price= product.Price,ProductId = product.ProductId, Description = product.Description,Category = new CategoryViewModel { CategoryId = product.CategoryId, Name = product.Category.Name} });
            
            return productsViewModel;
        }

        public static ProductViewModel MapToViewModel(this Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                Price = product.Price,
                Category = new CategoryViewModel { CategoryId = product.CategoryId, Name = product.Category.Name },
                Name = product.Name,
                Description = product.Description
            };
        }

    }
}
