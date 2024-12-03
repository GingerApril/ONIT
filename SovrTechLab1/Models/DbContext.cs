using Microsoft.EntityFrameworkCore;
namespace Laba1Marta.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TableModel> TableDB { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }


}
