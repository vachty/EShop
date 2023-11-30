namespace Service.Dtos
{
	/// <summary>
	/// The Search product response dto
	/// </summary>
	public class SearchProductResponseDto
	{
		public ICollection<ProductResponseDto> Products { get; set; }
	}
}
