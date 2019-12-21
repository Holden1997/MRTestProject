using MRTestProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MRTestProject.Infastructure
{
    public class ProductRepository : IRepository<Product> , IDisposable
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Product model)
        {
            _context.Add(model);

            Save();

            return true;
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public bool Delete(Product model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            
            Save();
            
            return true;
        }

        public bool Delete(Guid modelId)
        {
            var product = _context.Products.Find(modelId);
            if (product != null)
                _context.Remove(product);
            
            Save();

            return true;
        }

        public Product Get(Guid id)
        {
            return _context.Products.Include(_ => _.Category).First(_ => _.ProductId == id);
        }

        public IList<Product> Get(int limit, int offset)
        {
            return _context.Products.Skip(offset).Take(limit).Include(_=>_.Category).ToList();
        }

        public bool Update(Product model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _context.Dispose();

                disposedValue = true;
            }
        }

       
        public void Dispose()
        {
           
            Dispose(true);
           
        }

        public IList<Product> Get()
        {
            return _context.Products.ToList();
        }
        #endregion
    }
}
