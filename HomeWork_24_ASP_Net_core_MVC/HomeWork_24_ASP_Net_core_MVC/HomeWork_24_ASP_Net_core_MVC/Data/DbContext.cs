
using HomeWork_24_ASP_Net_core_MVC.Models;
using Microsoft.EntityFrameworkCore;



namespace HomeWork_24_ASP_Net_core_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
            //:base()
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
