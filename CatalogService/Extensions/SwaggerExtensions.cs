using Microsoft.OpenApi.Models;

namespace CatalogService.Extensions
{
	/// <summary>
	/// The Extensions for Swagger
	/// </summary>
	public static class SwaggerExtensions
	{
		/// <summary>
		/// Adds the swagget to the ServiceCollection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			var contact = new OpenApiContact()
			{
				Name = "Lukas Vachtarcik",
				Email = "lukas.vachtarcik@gmail.com",
				Url = new Uri("https://github.com/vachty/EShop")
			};

			var title = "Catalog service API";
			var version = "v1";

			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v1", new OpenApiInfo()
				{
					Version = version,
					Title = title + " V1",
					Contact = contact
				});

				x.SwaggerDoc("v2", new OpenApiInfo()
				{
					Version = version,
					Title = title + " V2",
					Contact = contact
				});

				x.ResolveConflictingActions(apiDesc => apiDesc.First());
				x.DocInclusionPredicate((docName, apiDesc) => apiDesc.GroupName == docName);
			});

			return services;
		}
	}
}
