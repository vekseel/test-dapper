using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MusicIndustry.Api.Core.Models.Contact;

namespace MusicIndustry.UI.Models.Contact;

public class ContactCreateEntryViewModel
{
    public FormModel Form { get; set; }
    public class FormModel : ContactCreateModel
    {
        
    }

    public ContactCreateEntryViewModel()
    {
        Items = new List<SelectListItem>();
    }

    public List<SelectListItem> Items { get; set; }

    public string PlatformIds { get; set; }
    public string LabelIds { get; set; }
    public string MusicianIds { get; set; }
}