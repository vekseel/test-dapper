using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicIndustry.Api.Core.Models.Contact;

namespace MusicIndustry.UI.Models.Contact;

public class ContactUpdateEntryViewModel
{
    public FormModel Form { get; set; }
    
    public class FormModel : ContactUpdateModel { }

    public ContactUpdateEntryViewModel()
    {
        Items = new List<SelectListItem>();
    }

    public List<SelectListItem> Items { get; set; }

    public string PlatformIds { get; set; }

    public string LabelIds { get; set; }

    public string MusicianIds { get; set; }
}