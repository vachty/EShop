using Service.Dtos.Product.Update;
using Swashbuckle.AspNetCore.Filters;

namespace CatalogService.Swagger.Examples
{
	/// <summary>
	/// Product update request dto example
	/// </summary>
	public class ProductUpdateRequestDtoExample : IExamplesProvider<ProductUpdateRequestDto>
	{
		/// <summary>
		/// Get the examples
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public ProductUpdateRequestDto GetExamples()
		{
			return new ProductUpdateRequestDto()
			{
				ProductId = Guid.Parse("547B7DCB-BA8A-401C-8558-B43AA38D75C5"),
				Description = "String"
			};
		}
	}
}
