namespace MusicIndustry.Api.Core.Models
{
    public record MusicianUpdateModel: MusicianCreateModel
    {
        public int Id { get; init; }
    }
}
