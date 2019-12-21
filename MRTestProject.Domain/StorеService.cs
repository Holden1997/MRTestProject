using System;
using System.Collections.Generic;
using System.Text;
using MRTestProject.Common;
using MRTestProject.Infastructure;

namespace MRTestProject.Domain
{
    public class StorеService : IStoreService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        public StorеService(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public void CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _categoryRepository.Create(category);
        }

        public void CreateProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _productRepository.Create(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public void DeleteCategory(Guid idCategory)
        {
            _categoryRepository.Delete(idCategory);
        }

        public void EditCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void EditProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public IList<Category> GetCategories()
        {
           
            return  _categoryRepository.Get();
        }

        public Category GetCategory(Guid idCategory)
        {
            return _categoryRepository.Get(idCategory);
        }

        public Product GetProduct(Guid idProduct)
        {
            return _productRepository.Get(idProduct);
        }

        public IList<Product> GetProducts(int? limit, int? offset)
        {
            limit = limit == null ? 10 : limit;
            offset = offset == null ? 0 : offset;

            return _productRepository.Get(limit.Value, offset.Value);
        }
    }
}
