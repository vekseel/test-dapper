using System;

namespace MusicIndustry.Api.Data.Models
{
    public interface IBaseEntryModel<T>
    {
        T Id { get; set; }
        DateTimeOffset DateCreated { get; set; }
    }
}
