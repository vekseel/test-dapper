namespace MusicIndustry.Api.Core.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public ResponseCode Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}
