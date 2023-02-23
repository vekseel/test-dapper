using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicIndustry.Api.Data.Stores;

namespace MusicIndustry.Api.Domain.Services
{
    public class MusicLabelService : BaseService, IMusicLabelService
    {
        public MusicLabelService(IMusicLabelStore store, ILogger<MusicLabelService> logger, IMapper mapper)
            : base(store, logger, mapper)
        {

        }
    }
}
