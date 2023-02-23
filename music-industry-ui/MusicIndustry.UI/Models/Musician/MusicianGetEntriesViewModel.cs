using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.UI.Helpers;
using static MusicIndustry.UI.Models.TableViewModel;

namespace MusicIndustry.UI.Models
{
    public class MusicianGetEntriesViewModel
    {
        public List<MusicianReportModel> Entries { get; set; } = new List<MusicianReportModel>();

        public TableViewModel GetTableViewModel(ViewDataDictionary ViewData)
        {
            return new TableViewModel
            {
                Name = (string)ViewData["Title"],
                CreateUrl = UIRoutesHelper.Musician.CreateEntry.GetUrl,
                UpdateUrl = UIRoutesHelper.Musician.UpdateEntry.GetUrl,
                DeleteUrl = UIRoutesHelper.Musician.DeleteEntry.GetUrl,
                Items = Entries ?? new List<MusicianReportModel>(),
                Columns = new List<TableViewModel.TableColumn>
                {
                    new TableViewModel.TableColumn(nameof(MusicianReportModel.Id))
                    {
                        IsIdentifier = true
                    },
                    new TableViewModel.TableColumn(nameof(MusicianReportModel.Name)),
                    new TableViewModel.TableColumn(nameof(MusicianReportModel.DateCreated)),
                    new TableViewModel.TableColumn(nameof(MusicianReportModel.DateModified)),
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
