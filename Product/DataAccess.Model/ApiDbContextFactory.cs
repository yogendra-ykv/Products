// In DataAccess.Model

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Model
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=.;Database=product_dev;Trusted_Connection=True;TrustServerCertificate=True;"); // Update with your connection string

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}