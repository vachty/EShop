using Service.Dtos.Product;
using Swashbuckle.AspNetCore.Filters;

namespace CatalogService.Swagger.Examples
{
	/// <summary>
	/// The Product Request Dto example
	/// </summary>
	public class ProductRequestDtoExample : IExamplesProvider<ProductRequestDto>
	{
		/// <summary>
		/// Get the examples
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public ProductRequestDto GetExamples()
		{
			return new ProductRequestDto()
			{
				ProductId = Guid.Parse("502FDA8A-6290-44DA-9310-4F0EDED03708")
			};
		}
	}
}
