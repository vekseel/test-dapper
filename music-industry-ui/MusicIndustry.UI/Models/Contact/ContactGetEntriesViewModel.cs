using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Core.Models.Query.Contact;
using MusicIndustry.UI.Helpers;

namespace MusicIndustry.UI.Models.Contact;

public class ContactGetEntriesViewModel
{
    public List<ContactsReportModel> Entries { get; set; } = new();

    public TableViewModel GetTableViewModel(ViewDataDictionary ViewData)
    {
        return new TableViewModel
        {
            Name = (string)ViewData["Title"],
            CreateUrl = UIRoutesHelper.Contact.CreateEntry.GetUrl,
            UpdateUrl = UIRoutesHelper.Contact.UpdateEntry.GetUrl,
            DeleteUrl = UIRoutesHelper.Contact.DeleteEntry.GetUrl,
            Items = Entries ?? new List<ContactsReportModel>(),
            Columns = new List<TableViewModel.TableColumn>
            {
                new(nameof(ContactsReportModel.Id))
                {
                    IsIdentifier = true
                },
                new(nameof(ContactsReportModel.FirstName)),
                new(nameof(ContactsReportModel.LastName)),
                new(nameof(ContactsReportModel.Email)),
                new(nameof(ContactsReportModel.PhoneCell)),
                new(nameof(ContactsReportModel.PhoneBusiness)),
                new(nameof(ContactsReportModel.IsActive)),
                new(nameof(ContactsReportModel.MusicLabels)),
                new(nameof(ContactsReportModel.Musicians)),
                new(nameof(ContactsReportModel.Platforms)),
                new()
                {
                    IsEdit = true
                },
                new()
                {
                    IsRemove = true
                }
            }
        };
    }
}