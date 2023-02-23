using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class PlatformUpdateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : PlatformUpdateModel
        {

        }
    }
}
