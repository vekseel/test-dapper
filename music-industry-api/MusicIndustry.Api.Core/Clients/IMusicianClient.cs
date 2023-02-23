using Refit;
using System.Threading.Tasks;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.Api.Core.Clients
{
    public interface IMusicianClient
    {
        [Get(RoutesHelper.Musician.Base)]
        Task<EntriesQueryResponse<MusicianReportModel>> GetEntries([Query] EntriesQueryRequest request);

        [Post(RoutesHelper.Musician.Base)]
        Task<CreateCommandResponse<int>> CreateEntry([Body] CreateCommandRequest<MusicianCreateModel> request);

        [Get(RoutesHelper.Musician.Id)]
        Task<EntryQueryResponse<MusicianReportModel>> GetEntry(int id);

        [Put(RoutesHelper.Musician.Id)]
        Task<UpdateCommandResponse> UpdateEntry(int id, [Body] UpdateCommandRequest<MusicianUpdateModel> request);

        [Delete(RoutesHelper.Musician.Id)]
        Task<DeleteCommandResponse> DeleteEntry(int id);
    }
}
