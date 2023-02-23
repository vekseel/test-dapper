using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.UI.Helpers;
using static MusicIndustry.UI.Models.TableViewModel;

namespace MusicIndustry.UI.Models
{
    public class PlatformGetEntriesViewModel
    {
        public List<PlatformReportModel> Entries { get; set; } = new List<PlatformReportModel>();

        public TableViewModel GetTableViewModel(ViewDataDictionary ViewData)
        {
            return new TableViewModel
            {
                Name = (string)ViewData["Title"],
                CreateUrl = UIRoutesHelper.Platform.CreateEntry.GetUrl,
                UpdateUrl = UIRoutesHelper.Platform.UpdateEntry.GetUrl,
                DeleteUrl = UIRoutesHelper.Platform.DeleteEntry.GetUrl,
                Items = Entries ?? new List<PlatformReportModel>(),
                Columns = new List<TableViewModel.TableColumn>
                {
                    new TableViewModel.TableColumn(nameof(PlatformReportModel.Id))
                    {
                        IsIdentifier = true
                    },
                    new TableViewModel.TableColumn(nameof(PlatformReportModel.Name)),
                    new TableViewModel.TableColumn(nameof(PlatformReportModel.DateCreated)),
                    new TableViewModel.TableColumn(nameof(PlatformReportModel.DateModified)),
                    new TableViewModel.TableColumn
                    {
                        IsEdit = true
                    },
                    new TableViewModel.TableColumn
                    {
                        IsRemove = true
                    }
                }
            };
        }
    }
}
