using System.Threading.Tasks;
using MusicIndustry.UI.Models;

namespace MusicIndustry.UI.Services
{
    public interface IPlatformService
    {
        Task<ServiceResult<PlatformGetEntriesViewModel>> GetEntries(int offset, int limit);
        ServiceResult<PlatformCreateEntryViewModel> GetCreateEntryViewModel();
        Task<ServiceResult> CreateEntry(PlatformCreateEntryViewModel.FormModel model);
        Task<ServiceResult<PlatformUpdateEntryViewModel>> GetUpdateEntryViewModel(int id);
        Task<ServiceResult> UpdateEntry(PlatformUpdateEntryViewModel.FormModel model);
        Task<ServiceResult> DeleteEntry(int id);
    }
}