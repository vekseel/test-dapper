using Microsoft.EntityFrameworkCore;
using MusicIndustry.Api.Data.Models;

namespace MusicIndustry.Api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MusicLabelContacts> MusicLabelContacts { get; set; } 
        public DbSet<MusicianContacts> MusicianContacts { get; set; } 
        public DbSet<PlatformContacts> PlatformContacts { get; set; } 
        public DbSet<ProcedureVersion> ProcedureVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);

            modelBuilder.DescribeMusicLabel();
            modelBuilder.DescribeMusician();
            modelBuilder.DescribePlatform();
            modelBuilder.DescribeContact();
            modelBuilder.DescribeMusicLabelContacts();
            modelBuilder.DescribeMusicianContacts();
            modelBuilder.DescribePlatformContact();
            modelBuilder.DescribeContact();
            modelBuilder.DescribeProcedureVersion();
        }
    }
}
