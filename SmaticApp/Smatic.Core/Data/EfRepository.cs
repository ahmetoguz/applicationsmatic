using Microsoft.EntityFrameworkCore;
using Smatic.Core.Entities;
using System;
using System.Linq;

namespace Smatic.Core.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    { 
        public readonly SmaticAppDbContext _context;
        private DbSet<T> _entities;

        public EfRepository(SmaticAppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

       
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Entities.Remove(entity);
            _context.SaveChanges();
        }
        public T GetById(object id)
        {
            return Entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
            _context.SaveChanges();

        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.SaveChanges();
        }

        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        ///     Entities
        /// </summary>
        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
