using Service.Dtos;
using Service.Results;

namespace Service.Handlers
{
	/// <summary>
	/// The Product handler interface
	/// </summary>
	public interface IProductHandler
	{
		IApiResult<SearchProductResponseDto> GetProducts();

		IApiResult<ProductResponseDto> GetProduct(Guid id);

		IApiResult<ProductResponseDto> UpdateProduct(UpdateProductRequestDto requestDto);
	}
}
