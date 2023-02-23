using Microsoft.Extensions.DependencyInjection;
using System;
using MusicIndustry.Api.Core.Clients;
using MusicIndustry.Api.Core.Models;

namespace MusicIndustry.Api.Core.Extensions
{
    public static class DependencyExtension
    {
        public static void AddApiClients(this IServiceCollection services, ApiConfig apiConfig)
        {
            services.AddSingleton<ApiConfig>(apiConfig);
            services.AddHttpClient(nameof(IMusicianClient),
                    c =>
                    {
                        c.BaseAddress = new Uri(apiConfig.BaseUrl);
                    })
                .AddTypedClient(c => Refit.RestService.For<IMusicianClient>(c));

            services.AddHttpClient(nameof(IMusicLabelClient),
                    c =>
                    {
                        c.BaseAddress = new Uri(apiConfig.BaseUrl);
                    })
                .AddTypedClient(c => Refit.RestService.For<IMusicLabelClient>(c));

            services.AddHttpClient(nameof(IPlatformClient),
                    c =>
                    {
                        c.BaseAddress = new Uri(apiConfig.BaseUrl);
                    })
                .AddTypedClient(c => Refit.RestService.For<IPlatformClient>(c));
            
            services.AddHttpClient(nameof(IContactClient),
                    c =>
                    {
                        c.BaseAddress = new Uri(apiConfig.BaseUrl);
                    })
                .AddTypedClient(c => Refit.RestService.For<IContactClient>(c));
        }
    }
}
