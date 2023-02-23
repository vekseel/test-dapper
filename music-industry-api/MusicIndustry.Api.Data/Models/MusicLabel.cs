using Microsoft.EntityFrameworkCore;
using System;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Data.Models
{
    public class MusicLabel : IBaseEntryModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }

    public static class MusicLabelExtension
    {
        public const string TABLE_NAME = "MusicLabels";

        public static void DescribeMusicLabel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicLabel>(c =>
            {
                c.Property(p => p.Name).IsRequired(true).HasMaxLength(ValidationHelper.MusicLabel.NameMaxLength).HasDefaultValue("('')");
                c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
                c.Property(p => p.DateModified).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
            });

            modelBuilder.Entity<MusicLabel>().ToTable(TABLE_NAME);
        }
    }
}
