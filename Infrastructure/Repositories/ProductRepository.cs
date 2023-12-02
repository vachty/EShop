using Domain;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	/// <summary>
	/// The Product repository
	/// </summary>
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		/// <summary>
		/// Create instance of the repository
		/// </summary>
		/// <param name="dbContext"></param>
		public ProductRepository(DbContext dbContext) : base(dbContext)
		{
		}

		/// <inheritdoc/>
		public async Task<IList<Product>> GetPagedListAsync(int pageSize, int offset)
		{
			return await Entities.Skip(offset).Take(pageSize).ToListAsync();
		}
	}
}
