using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Extensions
{
	public static class AppBuilderExtensions
	{
		public static WebApplication UseMigrations(this WebApplication app)
		{
			if (app == null)
				throw new ArgumentNullException(nameof(app));

			using(var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				using (var context = serviceScope.ServiceProvider.GetRequiredService<CatalogDbContext>())
				{
					context.Database.Migrate();
				}
			}

			return app;
		}

		public static WebApplication SetSwaggerUI(this WebApplication app)
		{
			if (app == null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(x =>
				{
					x.SwaggerEndpoint($"/swagger/v1/swagger.json", Constants.Constants.ApiTitleV1);
					x.SwaggerEndpoint($"/swagger/v2/swagger.json", Constants.Constants.ApiTitleV2);
				});
			}

			return app;
		}
	}
}
