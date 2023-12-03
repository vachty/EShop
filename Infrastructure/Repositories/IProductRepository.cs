using Domain;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
	/// <summary>
	/// The Product repository interface
	/// </summary>
	public interface IProductRepository : IBaseRepository<Product>
	{
		/// <summary>
		/// GEts the list of products with offest and with pagesize 
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		Task<IList<Product>> GetPagedListAsync(int pageSize, int offset);
	}
}
