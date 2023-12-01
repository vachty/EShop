using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Product Request Dto
    /// </summary>
    public class ProductRequestDto : BaseRequestDto<ProductResponseDto>
    {
        public Guid ProductId;
    }
}
