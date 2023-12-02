using Service.Dtos.Base;

namespace Service.Dtos.Product.V2
{
	public class SearchProductV2RequestDto : BaseRequestDto<SearchProductV2ResponseDto>
	{
		public int Offset { get; set; } = 0;
		public int PageSize { get; set; } = 10;
	}
}
