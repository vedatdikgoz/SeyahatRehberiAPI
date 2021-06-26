using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SeyahatRehberi.Core.Utilities.IoC;

namespace SeyahatRehberi.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
