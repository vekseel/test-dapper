using System.ComponentModel.DataAnnotations;

namespace MusicIndustry.Api.Core.Models
{
    public class UpdateCommandRequest<T> : BaseRequest
    {
        [Required]
        public T Entry { get; set; }
    }
}
