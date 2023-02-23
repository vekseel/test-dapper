namespace MusicIndustry.Api.Core.Models
{
    public class EntryQueryRequest<T> : BaseRequest
    {
        public T Id { get; set; }
    }
}
