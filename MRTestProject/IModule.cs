using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MRTestProject
{
    public interface IModule 
    {
        void Register(IServiceCollection services, IConfiguration configuration);

    }
}