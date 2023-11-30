using Service.Dtos;
using Service.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Handlers
{
	/// <summary>
	/// The Product handler
	/// </summary>
	public class ProductHandler : IProductHandler
	{
		public IApiResult<ProductResponseDto> GetProduct(Guid id)
		{
			throw new NotImplementedException();
		}

		public IApiResult<SearchProductResponseDto> GetProducts()
		{
			throw new NotImplementedException();
		}

		public IApiResult<ProductResponseDto> UpdateProduct(UpdateProductRequestDto requestDto)
		{
			throw new NotImplementedException();
		}
	}
}
