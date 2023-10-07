using Microsoft.Extensions.DependencyInjection;

namespace Library.Core.Application
{
	public static class ServiceExtensions
	{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(confic => confic.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));
            return services;
        }
    }
}
