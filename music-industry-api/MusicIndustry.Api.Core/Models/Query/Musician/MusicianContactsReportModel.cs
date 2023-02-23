using System.Collections.Generic;

namespace MusicIndustry.Api.Core.Models;

public class MusicianContactsReportModel
{
    public int Id { get; set; }
    
    public int ContactId { get; set; }
    
    public int MusicianId { get; set; }
}