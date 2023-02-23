using System.ComponentModel.DataAnnotations;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Core.Models
{
    public record PlatformCreateModel
    {
        [Required]
        [StringLength(ValidationHelper.Platform.NameMaxLength)]
        public string Name { get; init; }
    }
}
