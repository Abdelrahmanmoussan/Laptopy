using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Laptopy.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
    }
}
