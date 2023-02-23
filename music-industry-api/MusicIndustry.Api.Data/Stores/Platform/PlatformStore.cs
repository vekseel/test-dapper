using AutoMapper;
using System;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores
{
    public class PlatformStore : BaseStore, IPlatformStore
    {
        public PlatformStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
            : base(connectionStrings, context, mapper)
        {

        }

        protected override Type DataModelType => typeof(Platform);
        protected override string EntriesProcedureName => PlatformGetEntriesProcedure.Name;
        protected override string EntryProcedureName => PlatformGetEntriesProcedure.Name;
    }
}
