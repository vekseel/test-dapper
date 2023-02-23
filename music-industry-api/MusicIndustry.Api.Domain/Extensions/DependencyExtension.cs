using Microsoft.Extensions.DependencyInjection;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Data.Extensions;
using MusicIndustry.Api.Domain.Services;
using MusicIndustry.Api.Domain.Services;
using MusicIndustry.Api.Domain.Services.Contact;

namespace MusicIndustry.Api.Domain.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDomainDependencies(this IServiceCollection services, ConnectionStrings connectionStrings)
        {
            services.RegisterDataDependencies(connectionStrings);

            services.AddTransient<IMusicianService, MusicianService>();
            services.AddTransient<IMusicLabelService, MusicLabelService>();
            services.AddTransient<IPlatformService, PlatformService>();
            services.AddTransient<IContactService, ContactService>();
        }
    }
}
