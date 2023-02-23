using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class MusicianCreateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : MusicianCreateModel
        {

        }
    }
}
