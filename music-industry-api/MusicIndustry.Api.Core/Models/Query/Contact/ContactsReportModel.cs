using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIndustry.Api.Core.Models.Query.Contact
{
    public record ContactsReportModel
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Title { get; init; }
        public string Company { get; init; }
        public string Email { get; init; }
        public string PhoneCell { get; init; }
        public string PhoneBusiness { get; init; }
        public string Fax { get; init; }
        public string AddressLine1 { get; init; }
        public string AddressLine2 { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Zip { get; init; }
        public bool IsActive { get; init; }
        public DateTimeOffset DateCreated { get; init; }
        public DateTimeOffset DateModified { get; init; }

        public int Musicians { get; set; }
        public int Platforms { get; set; }
        public int MusicLabels { get; set; }
    }
}
