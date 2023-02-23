using System;
using Microsoft.EntityFrameworkCore;

namespace MusicIndustry.Api.Data.Models;

public class PlatformContacts
{
    public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public int PlatformId { get; set; }
    public Platform Platform { get; set; }

    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}

public static class PlatformContactExtension
{
    public const string TABLE_NAME = "PlatformContacts";

    public static void DescribePlatformContact(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlatformContacts>(c =>
        {
            c.HasKey(x => x.Id);
            c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
        });

        modelBuilder.Entity<PlatformContacts>()
            .HasOne((u) => u.Contact)
            .WithMany((c) => c.PlatformContacts)
            .HasForeignKey(p => new { p.ContactId });
        
        modelBuilder.Entity<PlatformContacts>().ToTable(TABLE_NAME);
    }
}