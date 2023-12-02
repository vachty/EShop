using Service.Dtos.Base;

namespace Service.Dtos.Product.V2
{
	public class SearchProductV2ResponseDto : BaseResponseDto
	{
		public ICollection<ProductResponseDto> Products { get; set; } = new List<ProductResponseDto>();
	}
}
