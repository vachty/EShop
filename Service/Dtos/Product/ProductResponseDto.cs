using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Product Response dto
    /// </summary>
    public class ProductResponseDto : BaseResponseDto
    {
        /// <summary>
        /// The name of the product
        /// </summary>
	    public string Name { get; set; }

        /// <summary>
        /// Uri of the product image
        /// </summary>
        public string ImgUri { get; set; }

        /// <summary>
        /// The product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        public string? Description { get; set; }
    }
}
