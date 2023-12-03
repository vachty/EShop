using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests.Database
{
	/// <summary>
	/// The db context for testing
	/// </summary>
	public class CatalogDbContextTest : CatalogDbContext
	{
		/// <summary>
		/// The Products collection
		/// </summary>
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// Create instance of testing CatalogDbContext
		/// </summary>
		/// <param name="options"></param>
		public CatalogDbContextTest(DbContextOptions<CatalogDbContext> options) : base(options)
		{
		}
	}
}
