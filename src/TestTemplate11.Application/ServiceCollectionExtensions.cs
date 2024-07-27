using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestTemplate11.Application.Pipelines;

namespace TestTemplate11.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestTemplate11ApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddPipelines();

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
