using System.ComponentModel.DataAnnotations;
using MusicIndustry.Api.Core.Helpers;

namespace MusicIndustry.Api.Core.Models
{
    public record MusicLabelCreateModel
    {
        [Required]
        [StringLength(ValidationHelper.MusicLabel.NameMaxLength)]
        public string Name { get; init; }
    }
}
