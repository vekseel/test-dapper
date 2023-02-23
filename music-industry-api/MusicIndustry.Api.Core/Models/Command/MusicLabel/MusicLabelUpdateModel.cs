namespace MusicIndustry.Api.Core.Models
{
    public record MusicLabelUpdateModel: MusicLabelCreateModel
    {
        public int Id { get; init; }
    }
}
