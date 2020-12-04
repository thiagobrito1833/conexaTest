using Microsoft.Extensions.DependencyInjection;
using Conexa.Domain.Contracts.Service;
using Conexa.Domain.Service;
using Conexa.Integration.Interface;
using Conexa.Integration;

namespace Conexa.Infra.Ioc
{
    public static class NativeInject
    {
        public static void RegisterServices(IServiceCollection services)    
        {

            services.AddScoped<IPlaylistService, PlaylistService>();
        }
    }
}
