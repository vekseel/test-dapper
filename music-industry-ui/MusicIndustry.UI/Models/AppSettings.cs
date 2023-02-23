using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.UI.Models
{
    public class AppSettings
    {
        public ApiConfig ApiConfig { get; set; }
        public PagingAppSettings Paging { get; set; }
    }

    public class PagingAppSettings
    {
        public int DefaultPageLimit { get; set; } = 10;
    }
}
