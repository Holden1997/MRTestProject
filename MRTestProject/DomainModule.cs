using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRTestProject.Domain;
using MRTestProject.Models;
using MRTestProject.Validation;

namespace MRTestProject
{
    public class DomainModule : IModule
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStoreService, StorеService>();
            services.AddTransient<IValidator<CategoryViewModel>, CategoryValidation>();
            services.AddTransient<IValidator<ProductViewModel>, ProductValidation>();
        }
    }
}
