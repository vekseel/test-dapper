using System;

namespace MusicIndustry.Api.Core.Models
{
    public record PlatformReportModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTimeOffset DateCreated { get; init; }
        public DateTimeOffset DateModified { get; init; }
    }
}
