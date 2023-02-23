using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicIndustry.Api.Core.Models.Contact;

namespace MusicIndustry.Api.Core.Helpers
{
    public static class ValidationHelper
    {
        public static class MusicLabel
        {
            public const int NameMaxLength = 50;
        }

        public static class Musician
        {
            public const int NameMaxLength = 50;
        }

        public static class Platform
        {
            public const int NameMaxLength = 50;
        }

        public static class Contact
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int TitleMaxLength = 50;
            public const int CompanyMaxLength = 150;
            public const int EmailMaxLength = 250;
            public const int PhoneCellMaxLength = 50;
            public const int PhoneBusinessMaxLength = 50;
            public const int FaxMaxLength = 50;
            public const int AddressLine1MaxLength = 50;
            public const int AddressLine2MaxLength = 50;
            public const int CityMaxLength = 50;
            public const int StateMaxLength = 50;
            public const int ZipMaxLength = 15;
            public const bool IsActiveDefaultValue = true;
        }

        public static bool ContactRequiredRelationsExist(this ContactCreateModel model)
        {
            if ((model.MusicianIds == null && model.MusicLabelIds == null && model.PlatformIds == null) || 
                 (model.MusicianIds.Count == 0 && model.MusicLabelIds.Count == 0 && model.PlatformIds.Count == 0))
            {
                return false;
            }
            
            return true;
        }
        
        public static bool ContactRequiredFieldsExist(this ContactCreateModel model)
        {
            if (String.IsNullOrEmpty(model.Email) && String.IsNullOrEmpty(model.Fax) && String.IsNullOrEmpty(model.PhoneBusiness) && String.IsNullOrEmpty(model.PhoneCell))
            {
                return false;
            }
            
            return true;
        }
    }
}
