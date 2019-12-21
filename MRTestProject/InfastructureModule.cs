using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRTestProject.Common;
using MRTestProject.Infastructure;

namespace MRTestProject
{
    public class InfastructureModule : IModule
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ApplicationContext"));
            using (var context = new ApplicationContext(optionsBuilder.Options)) context.Database.EnsureCreated();

            services.AddTransient(_ => new ApplicationContext(optionsBuilder.Options));

            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
        }
    }
}
