using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	/// <summary>
	/// The Catalog DB context
	/// </summary>
	public class CatalogDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			new ProductEntityConfig().Configure(builder.Entity<Product>());
		}
		
	}
}
