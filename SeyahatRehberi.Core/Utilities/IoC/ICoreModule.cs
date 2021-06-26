using Microsoft.Extensions.DependencyInjection;


namespace SeyahatRehberi.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
