namespace MusicIndustry.Api.Core.Models
{
    public class EntryQueryResponse<T>: BaseResponse
    {
        public T Data { get; set; }
    }
}
