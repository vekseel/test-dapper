using System.Collections.Generic;

namespace MusicIndustry.Api.Core.Models
{
    public class EntriesQueryResponse<T>: BaseResponse
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
