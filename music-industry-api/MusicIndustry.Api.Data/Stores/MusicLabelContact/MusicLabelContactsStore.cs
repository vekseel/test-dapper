using System;
using System.Threading.Tasks;
using AutoMapper;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Stores.MusicianContact;

public class MusicLabelContactsStore: BaseStore, IMusicLabelContactsStore
{
    public MusicLabelContactsStore(ConnectionStrings connectionStrings, ApplicationDbContext context, IMapper mapper)
        : base(connectionStrings, context, mapper)
    {
            
    }
    

    protected override Type DataModelType => typeof(MusicLabelContacts);
    protected override string EntriesProcedureName => MusicLabelContactsGetEntriesProcedure.Name;
    protected override string EntryProcedureName => MusicLabelContactsGetEntriesProcedure.Name;
}