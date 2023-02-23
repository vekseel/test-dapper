using System.ComponentModel.DataAnnotations;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Core.Models
{
    public record MusicianCreateModel
    {
        [Required]
        [StringLength(ValidationHelper.Musician.NameMaxLength)]
        public string Name { get; init; }
    }
}
