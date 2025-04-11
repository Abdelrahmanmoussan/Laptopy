using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Laptopy.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {



        // CRUD

        // Create Function
        public T Create(T entity);
        public void Create(IEnumerable<T> entities);

        // Update Function
        public void Edit(T entity);

        // Delete Function
        public void Delete(T entity);
        public void Delete(IEnumerable<T> entities);

        // Save Function
        public void Commit();
        // Get Function
        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);

        // Get One Function
        public T? GetOne(Expression<Func<T, bool>>? filters = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);
    }
}
