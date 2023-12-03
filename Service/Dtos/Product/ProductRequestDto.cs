using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Product Request Dto
    /// </summary>
    public class ProductRequestDto : BaseRequestDto<ProductResponseDto>
    {
        /// <summary>
        /// The Id of the Product
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
