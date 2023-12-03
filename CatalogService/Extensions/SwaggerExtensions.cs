using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CatalogService.Extensions
{
	/// <summary>
	/// The Extensions for Swagger
	/// </summary>
	public static class SwaggerExtensions
	{
		/// <summary>
		/// Adds the swagger to the ServiceCollection
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

				var executingAssembly = Assembly.GetExecutingAssembly();
				x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{executingAssembly.GetName().Name}.xml"));

				var referencedProjectsXmlDocPaths = executingAssembly.GetReferencedAssemblies()
					.Where(assembly => assembly.Name != null)
					.Select(assembly => Path.Combine(AppContext.BaseDirectory, $"{assembly.Name}.xml"))
					.Where(path => File.Exists(path));
				foreach (var xmlDocPath in referencedProjectsXmlDocPaths)
				{
					x.IncludeXmlComments(xmlDocPath);
				}

				x.ResolveConflictingActions(apiDesc => apiDesc.First());
				x.DocInclusionPredicate((docName, apiDesc) => apiDesc.GroupName == docName);
			});

			return services;
		}
	}
}
