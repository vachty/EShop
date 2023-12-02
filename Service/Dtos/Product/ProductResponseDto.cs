using Service.Dtos.Base;

namespace Service.Dtos.Product
{
    /// <summary>
    /// The Product Response dto
    /// </summary>
    public class ProductResponseDto : BaseResponseDto
    {
	    public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
