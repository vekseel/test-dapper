using System.Threading.Tasks;
using MusicIndustry.UI.Models;

namespace MusicIndustry.UI.Services
{
    public interface IMusicLabelService
    {
        Task<ServiceResult<MusicLabelGetEntriesViewModel>> GetEntries(int offset, int limit);
        ServiceResult<MusicLabelCreateEntryViewModel> GetCreateEntryViewModel();
        Task<ServiceResult> CreateEntry(MusicLabelCreateEntryViewModel.FormModel model);
        Task<ServiceResult<MusicLabelUpdateEntryViewModel>> GetUpdateEntryViewModel(int id);
        Task<ServiceResult> UpdateEntry(MusicLabelUpdateEntryViewModel.FormModel model);
        Task<ServiceResult> DeleteEntry(int id);
    }
}