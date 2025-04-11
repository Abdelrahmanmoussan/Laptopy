using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Laptopy.Repository
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ContactUsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
    }
}
