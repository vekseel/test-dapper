using System;
using Microsoft.EntityFrameworkCore;

namespace MusicIndustry.Api.Data.Models;

public class MusicLabelContacts : IBaseEntryModel<int>
{
    public int Id { get; set; }
    
    public int MusicLabelId { get; set; }
    
    public MusicLabel MusicLabel { get; set; }
    
    public int ContactId { get; set; }
    
    public Contact Contact { get; set; }
    
    public DateTimeOffset DateCreated { get; set; }
}

public static class MusicLabelContactExtension
{
    public const string TABLE_NAME = "MusicLabelContacts";

    public static void DescribeMusicLabelContacts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MusicLabelContacts>(c =>
        {
            c.HasKey(x => x.Id);
            c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
        });
        
        modelBuilder.Entity<MusicLabelContacts>()
            .HasOne((u) => u.Contact)
            .WithMany((c) => c.MusicLabelContacts)
            .HasForeignKey(p => new { p.ContactId });

        modelBuilder.Entity<MusicLabelContacts>().ToTable(TABLE_NAME);
    }
}