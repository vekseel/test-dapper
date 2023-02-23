using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class PlatformCreateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : PlatformCreateModel
        {

        }
    }
}
