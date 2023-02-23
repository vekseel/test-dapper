using System;
using Microsoft.EntityFrameworkCore;

namespace MusicIndustry.Api.Data.Models;

public class MusicianContacts : IBaseEntryModel<int>
{
    public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public int MusicianId { get; set; }
    public Musician Musician { get; set; }

    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}

public static class MusicianContactsExtension
{
    public const string TABLE_NAME = "MusicianContacts";

    public static void DescribeMusicianContacts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MusicianContacts>(c =>
        {
            c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
            c.HasKey(x => x.Id);
        });

        modelBuilder.Entity<MusicianContacts>()
            .HasOne((u) => u.Contact)
            .WithMany((c) => c.MusicianContacts)
            .HasForeignKey(p => new { p.ContactId });
        
        modelBuilder.Entity<MusicianContacts>().ToTable(TABLE_NAME);
    }
}