using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	/// <summary>
	/// The CatalogDbContext interface
	/// </summary>
	public interface ICatalogDbContext
	{
		/// <summary>
		/// The Products
		/// </summary>
		public DbSet<Product> Products { get; set; }
	}
}
