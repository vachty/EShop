using Infrastructure.Repositories;
using Service.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Service.Dtos.Product;
using Service.Handlers.Base;

namespace Service.Handlers
{
    /// <summary>
    /// The Product handler
    /// </summary>
    public class ProductSearchHandler : BaseHandler<SearchProductsRequestDto, SearchProductsResponseDto>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductSearchHandler(IProductRepository productRepository, IMapper mapper)
		{
			this._productRepository = productRepository;
			this._mapper = mapper;
		}

		public override async Task<IApiResult<SearchProductsResponseDto>> Handle(SearchProductsRequestDto request, CancellationToken cancellationToken)
		{
			var result = new ApiResult<SearchProductsResponseDto>();

			try
			{
				var productEntities = await _productRepository.GetAllAsync();

				var responseDto = new SearchProductsResponseDto();
				responseDto.Products = new List<ProductResponseDto>();

				foreach (var productEntity in productEntities)
				{
					responseDto.Products.Add(_mapper.Map<Product, ProductResponseDto>(productEntity));
				}

				result.Data = responseDto;
			}
			catch (Exception ex)
			{
				result.ErrorCode = "500";
				result.AddError(ex);
			}

			return result;
		}

	}
}
