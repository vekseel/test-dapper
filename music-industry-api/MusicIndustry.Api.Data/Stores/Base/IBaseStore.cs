using System.Threading.Tasks;
using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.Api.Data.Stores
{
    public interface IBaseStore
    {
        Task<EntriesQueryResponse<T>> GetEntries<T>(EntriesQueryRequest request);
        Task<EntryQueryResponse<T>> GetEntry<T, K>(EntryQueryRequest<K> request);
        Task<K> CreateEntry<T, K>(CreateCommandRequest<T> request);
        Task<bool> UpdateEntry<T, K>(UpdateCommandRequest<T> request);
        Task<bool> DeleteEntry<T>(DeleteCommandRequest<T> request);
    }
}