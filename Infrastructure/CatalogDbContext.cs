using Domain;
using Infrastructure.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	/// <summary>
	/// The Catalog DB context
	/// </summary>
	public class CatalogDbContext : DbContext, ICatalogDbContext
	{
		/// <inheritdoc/>
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// Creates instance of the database context
		/// </summary>
		/// <param name="options"></param>
		public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
		{
		}

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			new ProductEntityConfig().Configure(builder.Entity<Product>());
		}
	}
}
