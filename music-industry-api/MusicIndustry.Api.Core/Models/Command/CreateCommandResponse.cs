namespace MusicIndustry.Api.Core.Models
{
    public class CreateCommandResponse<T> : BaseResponse
    {
        public T Id { get; set; }
    }
}
