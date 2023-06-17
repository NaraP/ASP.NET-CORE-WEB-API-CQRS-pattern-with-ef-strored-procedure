using Microsoft.EntityFrameworkCore;

namespace APIEFCoreSQLSp.Models
{
    public class ProductDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProductDbContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Product { get; set; }
    }
}
