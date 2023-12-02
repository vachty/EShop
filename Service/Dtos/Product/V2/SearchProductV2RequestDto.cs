using Service.Dtos.Base;

namespace Service.Dtos.Product.V2
{
	/// <summary>
	/// The Search Product V2 request dto
	/// </summary>
	public class SearchProductV2RequestDto : BaseRequestDto<SearchProductV2ResponseDto>
	{
		public int Offset { get; set; } = 0;
		public int PageSize { get; set; } = 10;
	}
}
