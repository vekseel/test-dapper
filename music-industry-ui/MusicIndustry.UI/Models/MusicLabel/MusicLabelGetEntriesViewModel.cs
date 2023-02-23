using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.UI.Helpers;
using static MusicIndustry.UI.Models.TableViewModel;

namespace MusicIndustry.UI.Models
{
    public class MusicLabelGetEntriesViewModel
    {
        public List<MusicLabelReportModel> Entries { get; set; } = new List<MusicLabelReportModel>();

        public TableViewModel GetTableViewModel(ViewDataDictionary ViewData)
        {
            return new TableViewModel
            {
                Name = (string)ViewData["Title"],
                CreateUrl = UIRoutesHelper.MusicLabel.CreateEntry.GetUrl,
                UpdateUrl = UIRoutesHelper.MusicLabel.UpdateEntry.GetUrl,
                DeleteUrl = UIRoutesHelper.MusicLabel.DeleteEntry.GetUrl,
                Items = Entries ?? new List<MusicLabelReportModel>(),
                Columns = new List<TableViewModel.TableColumn>
                {
                    new TableViewModel.TableColumn(nameof(MusicLabelReportModel.Id))
                    {
                        IsIdentifier = true
                    },
                    new TableViewModel.TableColumn(nameof(MusicLabelReportModel.Name)),
                    new TableViewModel.TableColumn(nameof(MusicLabelReportModel.DateCreated)),
                    new TableViewModel.TableColumn(nameof(MusicLabelReportModel.DateModified)),
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
