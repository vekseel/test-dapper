using System;
using AutoMapper;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores.MusicianContact;

public class MusicianContactsStore: BaseStore, IMusicianContactsStore
{
    public MusicianContactsStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
        : base(connectionStrings, context, mapper)
    {
            
    }

    protected override Type DataModelType => typeof(Models.MusicianContacts);
    protected override string EntriesProcedureName => MusicianContactsGetEntriesProcedure.Name;
    protected override string EntryProcedureName => MusicianContactsGetEntriesProcedure.Name;
}