using MusicIndustry.Api.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicIndustry.UI.Models;
using MusicIndustry.UI.Services;
using MusicIndustry.UI.Services.Contact;

namespace MusicIndustry.UI.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var appsettings = config.Get<AppSettings>();
            services.AddSingleton<PagingAppSettings>(appsettings.Paging);

            services.AddApiClients(appsettings.ApiConfig);

            services.AddTransient<IMusicianService, MusicianService>();
            services.AddTransient<IMusicLabelService, MusicLabelService>();
            services.AddTransient<IPlatformService, PlatformService>();
            services.AddTransient<IContactService, ContactService>();
        }
    }
}
