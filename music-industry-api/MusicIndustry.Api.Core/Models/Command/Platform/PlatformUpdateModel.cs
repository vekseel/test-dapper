namespace MusicIndustry.Api.Core.Models
{
    public record PlatformUpdateModel: PlatformCreateModel
    {
        public int Id { get; init; }
    }
}
