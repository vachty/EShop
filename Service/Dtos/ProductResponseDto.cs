﻿namespace Service.Dtos
{
	public class ProductResponseDto
	{
		public string Name { get; set; }
		public string ImgUri { get; set; }
		public decimal Price { get; set; }
		public string? Description { get; set; }
	}
}
