using Microsoft.EntityFrameworkCore;
using System;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Data.Models
{
    public class Musician : IBaseEntryModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }

    public static class MusicianExtension
    {
        public const string TABLE_NAME = "Musicians";

        public static void DescribeMusician(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(c =>
            {
                c.Property(p => p.Name).IsRequired(true).HasMaxLength(ValidationHelper.Musician.NameMaxLength).HasDefaultValue("('')");
                c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
                c.Property(p => p.DateModified).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
            });

            modelBuilder.Entity<Musician>().ToTable(TABLE_NAME);
        }
    }
}
