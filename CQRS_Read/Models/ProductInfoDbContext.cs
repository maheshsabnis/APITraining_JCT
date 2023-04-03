using Microsoft.EntityFrameworkCore;

namespace CQRS_Read.Models
{
    public class ProductInfoDbContext : DbContext
    {
        public ProductInfoDbContext(DbContextOptions<ProductInfoDbContext> options):base(options) 
        {
        }
        /// <summary>
        /// Mapping 
        /// </summary>
        public DbSet<ProductInfo> Products { get; set; }

        /// <summary>
        /// Generate Mapping between the CLR class and Database Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
