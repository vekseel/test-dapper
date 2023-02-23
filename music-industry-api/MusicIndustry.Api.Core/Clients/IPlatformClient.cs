using Refit;
using System.Threading.Tasks;
using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.Api.Core.Clients
{
    public interface IPlatformClient
    {
        [Get(RoutesHelper.Platform.Base)]
        Task<EntriesQueryResponse<PlatformReportModel>> GetEntries([Query] EntriesQueryRequest request);

        [Post(RoutesHelper.Platform.Base)]
        Task<CreateCommandResponse<int>> CreateEntry([Body] CreateCommandRequest<PlatformCreateModel> request);

        [Get(RoutesHelper.Platform.Id)]
        Task<EntryQueryResponse<PlatformReportModel>> GetEntry(int id);

        [Put(RoutesHelper.Platform.Id)]
        Task<UpdateCommandResponse> UpdateEntry(int id, [Body] UpdateCommandRequest<PlatformUpdateModel> request);

        [Delete(RoutesHelper.Platform.Id)]
        Task<DeleteCommandResponse> DeleteEntry(int id);
    }
}
