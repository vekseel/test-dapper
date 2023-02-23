using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicIndustry.Api.Data.Stores;

namespace MusicIndustry.Api.Domain.Services
{
    public class PlatformService : BaseService, IPlatformService
    {
        public PlatformService(IPlatformStore store, ILogger<PlatformService> logger, IMapper mapper)
            : base(store, logger, mapper)
        {

        }
    }
}
