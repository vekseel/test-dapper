using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicIndustry.Api.Core.Models.Contact;

public record ContactReportModel
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Title { get; init; }
    public string Company { get; init; }
    public string Email { get; init; }
    public string PhoneCell { get; init; }
    public string PhoneBusiness { get; init; }
    public string Fax { get; init; }
    public string AddressLine1 { get; init; }
    public string AddressLine2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public bool IsActive { get; init; }
    public DateTimeOffset DateCreated { get; init; }
    public DateTimeOffset DateModified { get; init; }
    
    public IEnumerable<MusicianReportModel> Musicians { get; set; }
    public IEnumerable<PlatformReportModel> Platforms { get; set; }
    public IEnumerable<MusicLabelReportModel> MusicLabels { get; set; }
}