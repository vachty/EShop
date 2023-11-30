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
	}
}
