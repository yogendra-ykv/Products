using Microsoft.EntityFrameworkCore;

namespace DataAccess.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.ProductSequence"); // Use the sequence to generate IDs

            base.OnModelCreating(modelBuilder);
        }
    }
}