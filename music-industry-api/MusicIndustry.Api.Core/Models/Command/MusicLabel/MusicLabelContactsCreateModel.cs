using System.ComponentModel.DataAnnotations;

namespace MusicIndustry.Api.Core.Models;

public record MusicLabelContactsCreateModel
{
    [Required]
    public int MusicLabelId { get; set; }
    
    [Required]
    public int ContactId { get; set; }
}