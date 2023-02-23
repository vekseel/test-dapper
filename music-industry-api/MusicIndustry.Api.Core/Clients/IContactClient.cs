using System.Threading.Tasks;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Core.Models.Query.Contact;
using Refit;

namespace MusicIndustry.Api.Core.Clients;

public interface IContactClient
{
    [Get(RoutesHelper.Contact.Base)]
    Task<EntriesQueryResponse<ContactsReportModel>> GetEntries([Query] EntriesQueryRequest request);

    [Post(RoutesHelper.Contact.Base)]
    Task<CreateCommandResponse<int>> CreateEntry([Body] CreateCommandRequest<ContactCreateModel> request);

    [Get(RoutesHelper.Contact.Id)]
    Task<EntryQueryResponse<ContactReportModel>> GetEntry(int id);

    [Put(RoutesHelper.Contact.Id)]
    Task<UpdateCommandResponse> UpdateEntry(int id, [Body] UpdateCommandRequest<ContactUpdateModel> request);

    [Delete(RoutesHelper.Contact.Id)]
    Task<DeleteCommandResponse> DeleteEntry(int id);
}