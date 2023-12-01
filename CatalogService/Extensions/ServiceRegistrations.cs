using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Handlers;
using Service.Mappers.Base;

namespace CatalogService.Extensions
{
	/// <summary>
	/// Register the services
	/// </summary>
	public static class ServiceRegistrations
	{
		public static IServiceCollection Register(this IServiceCollection services)
		{
			services.AddScoped<IBaseMapper, BaseMapper>();
			services.AddScoped<DbContext, CatalogDbContext>();
			services.AddScoped<IProductRepository, ProductRepository>();

			return services;
		}
	}
}
