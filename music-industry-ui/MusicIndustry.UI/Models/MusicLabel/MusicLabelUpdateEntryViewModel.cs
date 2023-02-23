using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class MusicLabelUpdateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : MusicLabelUpdateModel
        {

        }
    }
}
