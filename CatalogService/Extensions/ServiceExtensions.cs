using Asp.Versioning;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CatalogService.Extensions
{
	/// <summary>
	/// The extensions for ServiceCollection
	/// </summary>
	public static class ServiceExtensions
	{
		/// <summary>
		/// Set ups the routing and versioning
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection SetUpRoutes(this IServiceCollection services)
		{
			// configure route options
			services.Configure<RouteOptions>(options =>
			{
				options.LowercaseUrls = true;
				options.AppendTrailingSlash = true;
			});

			// register MVC services
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = ApiVersion.Default;
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
			}).AddMvc().AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}

		/// <summary>
		/// Adds the dbcontext to the service collection
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
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
