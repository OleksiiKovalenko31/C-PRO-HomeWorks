using Microsoft.EntityFrameworkCore;
using HomeWork_26_WebAPI_Middleware_RESTAPI.Models;

namespace HomeWork_26_WebAPI_Middleware_RESTAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Products> Products { get; set; }
        // Додамо інші таблиці пізніше (Product, Customer, Order)
    }
}
