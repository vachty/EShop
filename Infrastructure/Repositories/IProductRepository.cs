using Domain;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
	/// <summary>
	/// The Product repository interface
	/// </summary>
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<IList<Product>> GetPagedListAsync(int pageSize, int offset);
	}
}
