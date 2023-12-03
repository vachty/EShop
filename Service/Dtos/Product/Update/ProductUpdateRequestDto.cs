using Service.Dtos.Base;

namespace Service.Dtos.Product.Update
{
	/// <summary>
	/// The Product Update Request Dto
	/// </summary>
	public class ProductUpdateRequestDto : BaseRequestDto<ProductUpdateResponseDto>
	{
		/// <summary>
		/// The Id of the product
		/// </summary>
		public Guid ProductId { get; set; }

		/// <summary>
		/// The Id of the product
		/// </summary>
		public string Description { get; set; }
	}
}
