using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class MusicLabelCreateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : MusicLabelCreateModel
        {

        }
    }
}
