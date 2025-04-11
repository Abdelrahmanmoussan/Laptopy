using Laptopy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laptopy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Category> categories {  get; set; }
        DbSet<ContactUs> contactUs { get; set; }
        DbSet<Product> products { get; set; }
        DbSet<ProductImages> productsImages { get; set; }


            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }
    }
}
