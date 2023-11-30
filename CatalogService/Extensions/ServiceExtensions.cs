using System.Reflection;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddCatalogDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			if (services == null)
				throw new ArgumentNullException(nameof(services));

			// add eTM db context
			services.AddDbContext<CatalogDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("Catalog"),
					sqlOptions =>
					{
						sqlOptions.MigrationsAssembly(typeof(CatalogDbContext).GetTypeInfo().Assembly.GetName().Name);
						sqlOptions.EnableRetryOnFailure(5);
					});
			});

			return services;
		}
	}
}
