using Microsoft.EntityFrameworkCore;

namespace Laba1Marta.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TableModel> TableDB { get; set; }
    }
}
