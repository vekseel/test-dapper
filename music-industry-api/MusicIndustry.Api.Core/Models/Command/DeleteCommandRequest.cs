namespace MusicIndustry.Api.Core.Models
{
    public class DeleteCommandRequest<T> : BaseRequest
    {
        public T Id { get; set; }
    }
}
