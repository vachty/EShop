using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Search product response dto
    /// </summary>
    public class SearchProductsResponseDto : BaseResponseDto
    {
        public ICollection<ProductResponseDto> Products { get; set; }
    }
}
