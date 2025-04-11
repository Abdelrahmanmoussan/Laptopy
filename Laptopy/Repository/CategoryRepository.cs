using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;

namespace Laptopy.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
    }
}
