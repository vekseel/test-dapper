using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicIndustry.Api.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=musicIndustryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
