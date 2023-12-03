using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Search product response dto
    /// </summary>
    public class SearchProductsResponseDto : BaseResponseDto
    {
        /// <summary>
        /// The collection of products
        /// </summary>
        public ICollection<ProductResponseDto> Products { get; set; } = new List<ProductResponseDto>();
    }
}
