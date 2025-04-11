using Laptopy.Data;
using Laptopy.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Laptopy.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public DbSet<T> dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
            dbSet = dbContext.Set<T>();
        }


        // CRUD

        // Create Function
        public T Create(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            
            return entity;
        }
        public void Create(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            dbContext.SaveChanges();
        }

        // Update Function
        public void Edit(T entity)
        {
            dbSet.Update(entity);
            dbContext.SaveChanges();
        }

        // Delete Function
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
        public void Delete (IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        // Save Function
        public void Commit()
        {
            dbContext.SaveChanges();
        }
        // Get Function
        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null ,Expression<Func<T, object>>[]? includes = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            } 

            if (includes != null)
            {
                foreach (var include in includes)
                {
                   query = query.Include(include);
                }
            }

            if (!tracked)
            {
                query =query.AsNoTracking();
            }

            return query.ToList();
        }

        // Get One Function
        public T? GetOne(Expression<Func<T , bool>>? filters = null, Expression<Func<T , object>>[]? includes = null, bool tracked = true)
        {
            return Get(filters, includes, tracked).FirstOrDefault();
        }



















    }
}
