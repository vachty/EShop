using Service.Dtos.Base;

namespace Service.Dtos.Product.V2
{
	/// <summary>
	/// The Search Product V2 response dto
	/// </summary>
	public class SearchProductV2ResponseDto : BaseResponseDto
	{
		public ICollection<ProductResponseDto> Products { get; set; } = new List<ProductResponseDto>();
	}
}
