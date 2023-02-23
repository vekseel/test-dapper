using System.ComponentModel.DataAnnotations;

namespace MusicIndustry.Api.Core.Models;

public record PlatformContactsCreateModel
{
    [Required]
    public int PlatformId { get; set; }
    
    [Required]
    public int ContactId { get; set; }
}