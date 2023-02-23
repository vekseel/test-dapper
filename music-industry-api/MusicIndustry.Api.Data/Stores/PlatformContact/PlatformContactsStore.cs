using System;
using AutoMapper;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores.MusicianContact;

public class PlatformContactsStore: BaseStore, IPlatformContactsStore
{
    public PlatformContactsStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
        : base(connectionStrings, context, mapper)
    {
            
    }

    protected override Type DataModelType => typeof(PlatformContacts);
    protected override string EntriesProcedureName => PlatformContactsGetEntriesProcedure.Name;
    protected override string EntryProcedureName => PlatformContactsGetEntriesProcedure.Name;
}