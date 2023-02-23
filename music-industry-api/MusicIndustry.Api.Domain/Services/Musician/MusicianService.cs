using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicIndustry.Api.Data.Stores;

namespace MusicIndustry.Api.Domain.Services
{
    public class MusicianService: BaseService, IMusicianService
    {
        public MusicianService(IMusicianStore store, ILogger<MusicianService> logger, IMapper mapper)
            : base(store, logger, mapper)
        {
            
        }
    }
}
