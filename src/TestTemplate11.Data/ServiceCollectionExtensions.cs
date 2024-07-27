using Microsoft.Extensions.DependencyInjection;
using TestTemplate11.Common.Interfaces;
using TestTemplate11.Core.Interfaces;
using TestTemplate11.Data.Repositories;

namespace TestTemplate11.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSpecificRepositories(this IServiceCollection services) =>
            services.AddScoped<IFooRepository, FooRepository>();

        public static void AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
