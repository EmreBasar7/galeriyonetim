using Microsoft.EntityFrameworkCore;

namespace galeriyonetim.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<arac> arac { get; set; }

        public DbSet<arac> aracs { get; set; } 
    }
}
