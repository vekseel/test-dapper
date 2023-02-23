using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class MusicianUpdateEntryViewModel
    {
        public FormModel Form { get; set; }
        public record FormModel : MusicianUpdateModel
        {

        }
    }
}
