using System.Reflection;
using Asp.Versioning;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Extensions
{
	public static class ServiceExtensions
	{
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
				options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
					new HeaderApiVersionReader("x-api-version"),
					new MediaTypeApiVersionReader("x-api-version"));
			}).AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}

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
