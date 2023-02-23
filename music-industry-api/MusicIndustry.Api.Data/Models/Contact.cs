using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Data.Models;

public class Contact : IBaseEntryModel<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string PhoneCell { get; set; }
    public string PhoneBusiness { get; set; }
    public string Fax { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }
    
    public IEnumerable<MusicLabelContacts> MusicLabelContacts { get; set; }
    
    public IEnumerable<MusicianContacts> MusicianContacts { get; set; }
    
    public IEnumerable<PlatformContacts> PlatformContacts { get; set; }
}

public static class ContactExtension
{
    public const string TABLE_NAME = "Contacts";

    public static void DescribeContact(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(c =>
        {
            c.Property(p => p.FirstName).IsRequired(true).HasMaxLength(ValidationHelper.Contact.FirstNameMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.LastName).IsRequired(true).HasMaxLength(ValidationHelper.Contact.LastNameMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.Title).IsRequired(false).HasMaxLength(ValidationHelper.Contact.TitleMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.Company).IsRequired(false).HasMaxLength(ValidationHelper.Contact.CompanyMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.Email).IsRequired(false).HasMaxLength(ValidationHelper.Contact.EmailMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.PhoneCell).IsRequired(false).HasMaxLength(ValidationHelper.Contact.PhoneCellMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.PhoneBusiness).IsRequired(false).HasMaxLength(ValidationHelper.Contact.PhoneBusinessMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.Fax).IsRequired(false).HasMaxLength(ValidationHelper.Contact.FaxMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.AddressLine1).IsRequired(false).HasMaxLength(ValidationHelper.Contact.AddressLine1MaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.AddressLine2).IsRequired(false).HasMaxLength(ValidationHelper.Contact.AddressLine2MaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.City).IsRequired(false).HasMaxLength(ValidationHelper.Contact.CityMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.State).IsRequired(false).HasMaxLength(ValidationHelper.Contact.StateMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.Zip).IsRequired(false).HasMaxLength(ValidationHelper.Contact.ZipMaxLength).HasDefaultValue(String.Empty);
            c.Property(p => p.IsActive).IsRequired(true).HasDefaultValue(ValidationHelper.Contact.IsActiveDefaultValue);
            c.Property(p => p.DateCreated).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
            c.Property(p => p.DateModified).HasDefaultValueSql("(SYSDATETIMEOFFSET())");
        });

        modelBuilder.Entity<Contact>().ToTable(TABLE_NAME);
    }
}