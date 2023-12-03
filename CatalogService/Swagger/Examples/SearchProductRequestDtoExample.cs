using Service.Dtos.Product;
using Swashbuckle.AspNetCore.Filters;

namespace CatalogService.Swagger.Examples
{
	/// <summary>
	/// The Search product request dto example
	/// </summary>
	public class SearchProductRequestDtoExample : IExamplesProvider<SearchProductsRequestDto>
	{
		/// <summary>
		/// Get the examples
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public SearchProductsRequestDto GetExamples()
		{
			return new SearchProductsRequestDto();
		}
	}
}
