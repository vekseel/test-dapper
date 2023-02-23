namespace MusicIndustry.Api.Core.Models
{
    public class EntriesQueryRequest: BaseRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
