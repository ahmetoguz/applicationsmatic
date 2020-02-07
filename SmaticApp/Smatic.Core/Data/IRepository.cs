using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smatic.Core.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get;}
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}


