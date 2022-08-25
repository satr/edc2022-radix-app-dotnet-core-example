using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}