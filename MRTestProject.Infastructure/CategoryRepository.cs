using MRTestProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MRTestProject.Infastructure
{
    public class CategoryRepository : IRepository<Category> , IDisposable
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Category model)
        {
            _context.Add(model);

            Save();

            return true;
        }

        public bool Delete(Category model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            
            Save();

            return true;
        }

        public bool Delete(Guid modelId)
        {
            var category = _context.Categories.Find(modelId);
            if (category != null)
                _context.Remove(category);

            Save();

            return true;

        }

        public Category Get(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public IList<Category> Get(int limit, int  offset)
        {
            return _context.Categories.Skip(offset).Take(limit).ToList();
        }

        public bool Update(Category model)
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
        private void Save()
        {

            _context.SaveChanges();

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

       
        void IDisposable.Dispose()
        {
           
            Dispose(true);
         
        }

        public IList<Category> Get()
        {
            return _context.Categories.ToList();
        }
        #endregion
    }
}
