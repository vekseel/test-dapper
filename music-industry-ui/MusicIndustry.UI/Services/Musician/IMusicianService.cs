﻿using System.Threading.Tasks;
using MusicIndustry.UI.Models;

namespace MusicIndustry.UI.Services
{
    public interface IMusicianService
    {
        Task<ServiceResult<MusicianGetEntriesViewModel>> GetEntries(int offset, int limit);
        ServiceResult<MusicianCreateEntryViewModel> GetCreateEntryViewModel();
        Task<ServiceResult> CreateEntry(MusicianCreateEntryViewModel.FormModel model);
        Task<ServiceResult<MusicianUpdateEntryViewModel>> GetUpdateEntryViewModel(int id);
        Task<ServiceResult> UpdateEntry(MusicianUpdateEntryViewModel.FormModel model);
        Task<ServiceResult> DeleteEntry(int id);
    }
}