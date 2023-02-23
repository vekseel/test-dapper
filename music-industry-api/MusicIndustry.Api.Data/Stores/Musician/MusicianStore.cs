using AutoMapper;
using System;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores
{
    public class MusicianStore: BaseStore, IMusicianStore
    {
        public MusicianStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
            : base(connectionStrings, context, mapper)
        {
            
        }

        protected override Type DataModelType => typeof(Musician);
        protected override string EntriesProcedureName => MusicianGetEntriesProcedure.Name;
        protected override string EntryProcedureName => MusicianGetEntriesProcedure.Name;
    }
}
