﻿using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Extensions
{
	/// <summary>
	/// Register the services to implement and use DI
	/// </summary>
	public static class ServiceRegistrations
	{
		/// <summary>
		/// Register the components
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection Register(this IServiceCollection services)
		{
			services.AddScoped<DbContext, CatalogDbContext>();
			services.AddScoped<IProductRepository, ProductRepository>();

			return services;
		}
	}
}
