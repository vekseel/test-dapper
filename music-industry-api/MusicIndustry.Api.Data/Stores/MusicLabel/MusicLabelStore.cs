using AutoMapper;
using System;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores
{
    public class MusicLabelStore : BaseStore, IMusicLabelStore
    {
        public MusicLabelStore(ConnectionStrings connectionStrings,ApplicationDbContext context, IMapper mapper)
            : base(connectionStrings, context, mapper)
        {

        }

        protected override Type DataModelType => typeof(MusicLabel);
        protected override string EntriesProcedureName => MusicLabelGetEntriesProcedure.Name;
        protected override string EntryProcedureName => MusicLabelGetEntriesProcedure.Name; 
    }
}
