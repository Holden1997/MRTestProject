using MRTestProject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRTestProject.Domain
{
    public interface IStoreService
    {
        Category GetCategory(Guid idCategory);
        IList<Category> GetCategories();
        void CreateCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(Guid idCategory);


        Product GetProduct(Guid idProduct);
        IList<Product> GetProducts(int? limit,int? offset);
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void Delete(Product product);
        
    }
}
