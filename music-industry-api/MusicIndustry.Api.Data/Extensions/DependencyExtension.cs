using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.AutoMapper;
using MusicIndustry.Api.Data.Stores;
using MusicIndustry.Api.Data.Stores.Contact;
using MusicIndustry.Api.Data.Stores.MusicianContact;

namespace MusicIndustry.Api.Data.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDataDependencies(this IServiceCollection services, ConnectionStrings connectionStrings)
        {
            if (!services.Any(s => s.ServiceType == typeof(ConnectionStrings)))
            {
                services.AddSingleton<ConnectionStrings>(connectionStrings);
            }

            services.AddAutoMapper(typeof(DataMapperProfile));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionStrings.DefaultConnection));

            services.AddTransient<IMusicianStore, MusicianStore>();
            services.AddTransient<IMusicLabelStore, MusicLabelStore>();
            services.AddTransient<IPlatformStore, PlatformStore>();
            services.AddTransient<IContactStore, ContactStore>();
            services.AddTransient<IMusicLabelContactsStore, MusicLabelContactsStore>();
            services.AddTransient<IMusicianContactsStore, MusicianContactsStore>();
            services.AddTransient<IPlatformContactsStore, PlatformContactsStore>();
        }
    }
}
