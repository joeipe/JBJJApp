using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace SharedKernel.Data
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext DataContext;
        protected DbSet<TEntity> DataTable;

        public GenericRepository(DbContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }
            DataContext = dataContext;
            DataTable = DataContext.Set<TEntity>();
        }

        public virtual void Add(params TEntity[] items)
        {
            Edit(items);
        }

        public virtual void Delete(params TEntity[] items)
        {
            Edit(items);
        }

        public virtual void Edit(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                DataTable.Add(item);
                DataContext.FixState();
            }
            Save();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DataTable.AsNoTracking();
        }

        public virtual TEntity GetById(int id)
        {
            return DataTable.AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public virtual IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DataTable.AsNoTracking().Where(predicate);
        }

        public virtual IQueryable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties);
        }

        public virtual IQueryable<TEntity> SearchForInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate);
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = DataTable.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual void Save()
        {
            DataContext.SaveChanges();
        }
    }
}
    