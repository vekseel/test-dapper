using System.ComponentModel.DataAnnotations;

namespace MusicIndustry.Api.Core.Models;

public record MusicianContactsCreateModel
{
    [Required]
    public int MusicianId { get; set; }
    
    [Required]
    public int ContactId { get; set; }
}