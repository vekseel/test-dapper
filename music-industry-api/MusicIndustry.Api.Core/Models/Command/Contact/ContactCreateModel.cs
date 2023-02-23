using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Core.Models.Contact;

public class ContactCreateModel
{
    [Required]
    [StringLength(ValidationHelper.Contact.FirstNameMaxLength)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(ValidationHelper.Contact.LastNameMaxLength)]
    public string LastName { get; set; }
    
    [StringLength(ValidationHelper.Contact.TitleMaxLength)]
    public string? Title { get; set; }
    
    [StringLength(ValidationHelper.Contact.CompanyMaxLength)]
    public string? Company { get; set; }
    
    [StringLength(ValidationHelper.Contact.EmailMaxLength)]
    public string? Email { get; set; }
    
    [StringLength(ValidationHelper.Contact.PhoneCellMaxLength)]
    public string? PhoneCell { get; set; }
    
    [StringLength(ValidationHelper.Contact.PhoneBusinessMaxLength)]
    public string? PhoneBusiness { get; set; }
    
    [StringLength(ValidationHelper.Contact.FaxMaxLength)]
    public string? Fax { get; set; }
    
    [StringLength(ValidationHelper.Contact.AddressLine1MaxLength)]
    public string? AddressLine1 { get; set; }
    
    [StringLength(ValidationHelper.Contact.AddressLine2MaxLength)]
    public string? AddressLine2 { get; set; }
    
    [StringLength(ValidationHelper.Contact.CityMaxLength)]
    public string? City { get; set; }
    
    [StringLength(ValidationHelper.Contact.StateMaxLength)]
    public string? State { get; set; }
    
    [StringLength(ValidationHelper.Contact.ZipMaxLength)]
    public string? Zip { get; set; }
    
    public bool IsActive { get; set; }
    
    public List<MusicLabelContactsCreateModel> MusicLabelIds { get; set; }
    
    public List<MusicianContactsCreateModel> MusicianIds { get; set; }
    
    public List<PlatformContactsCreateModel> PlatformIds { get; set; }
}