using Microsoft.EntityFrameworkCore;
using ecommerce_website.Models;

namespace ecommerce_website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Ye line batati hai ke database mein 'Products' naam ka table hoga
        public DbSet<Product> Products { get; set; }
    }
}