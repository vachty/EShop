using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Service.Dtos.Product;
using Service.Handlers.Base;
using Service.Results;

namespace Service.Handlers
{
	/// <summary>
	/// The Product search handler
	/// </summary>
	public class ProductSearchHandler : BaseHandler<SearchProductsRequestDto, SearchProductsResponseDto>
	{
		/// <summary>
		/// The product repository
		/// </summary>
		private readonly IProductRepository _productRepository;

		/// <summary>
		/// The mapper
		/// </summary>
		private readonly IMapper _mapper;

		/// <summary>
		/// Create instance of the handler
		/// </summary>
		/// <param name="productRepository"></param>
		/// <param name="mapper"></param>
		public ProductSearchHandler(IProductRepository productRepository, IMapper mapper)
		{
			this._productRepository = productRepository;
			this._mapper = mapper;
		}

		/// <inheritdoc/>
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
