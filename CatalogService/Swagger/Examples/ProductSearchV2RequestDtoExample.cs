using Service.Dtos.Product.V2;
using Swashbuckle.AspNetCore.Filters;

namespace CatalogService.Swagger.Examples
{
	/// <summary>
	/// The Product Search V2 Request dto example
	/// </summary>
	public class ProductSearchV2RequestDtoExample : IExamplesProvider<SearchProductV2RequestDto>
	{
		/// <summary>
		/// Get the examples
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public SearchProductV2RequestDto GetExamples()
		{
			return new SearchProductV2RequestDto()
			{
				Offset = 0,
				PageSize = 10
			};
		}
	}
}
