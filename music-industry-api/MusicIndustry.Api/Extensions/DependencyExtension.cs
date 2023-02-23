using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using MusicIndustry.Api.Common.Models;
using MusicIndustry.Api.Domain.Extensions;

namespace MusicIndustry.Api.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterApiDependencies(this IServiceCollection services, IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var appsettings = config.Get<AppSettings>();

            services.RegisterDomainDependencies(appsettings.ConnectionStrings);
        }
    }
}
