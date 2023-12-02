using Service.Dtos.Base;

namespace Service.Dtos.Product.Update
{
	/// <summary>
	/// The Product Update Request Dto
	/// </summary>
	public class ProductUpdateRequestDto : BaseRequestDto<ProductUpdateResponseDto>
	{
		public Guid ProductId { get; set; }
		public string Description { get; set; }
	}
}
