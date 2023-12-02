using Microsoft.OpenApi.Models;
using static System.Net.WebRequestMethods;

namespace CatalogService.Extensions
{
	public static class SwaggerExtensions
	{
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
