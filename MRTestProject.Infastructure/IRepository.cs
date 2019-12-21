using System;
using System.Collections.Generic;
using System.Text;

namespace MRTestProject.Infastructure
{
    public interface IRepository<TModel>
    {
        bool Create(TModel model);
        TModel Get(Guid id);
        IList<TModel> Get(int limit, int offset);
        IList<TModel> Get();
        bool Delete(TModel model);
        bool Delete(Guid id);
        bool Update(TModel model);
    }
}
