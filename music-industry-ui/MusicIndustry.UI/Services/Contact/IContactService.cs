using System.Threading.Tasks;
using MusicIndustry.UI.Models;
using MusicIndustry.UI.Models.Contact;

namespace MusicIndustry.UI.Services.Contact;

public interface IContactService
{
    Task<ServiceResult<ContactGetEntriesViewModel>> GetEntries(int offset, int limit);
    Task<ServiceResult<ContactCreateEntryViewModel>> GetCreateEntryViewModel();
    Task<ServiceResult> CreateEntry(ContactCreateEntryViewModel viewModel);
    Task<ServiceResult<ContactUpdateEntryViewModel>> GetUpdateEntryViewModel(int id);
    Task<ServiceResult> UpdateEntry(ContactUpdateEntryViewModel viewModel);
    Task<ServiceResult> DeleteEntry(int id);
}