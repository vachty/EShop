using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Service.Dtos.Product;
using Service.Dtos.Product.V2;
using Service.Handlers.Base;
using Service.Results;

namespace Service.Handlers.V2
{
	/// <summary>
	/// The Product Search V2 Handler
	/// </summary>
	public class ProductSearchV2Handler : BaseHandler<SearchProductV2RequestDto, SearchProductV2ResponseDto>
	{
		/// <summary>
		/// The Product repository
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
		public ProductSearchV2Handler(IProductRepository productRepository, IMapper mapper)
		{
			this._productRepository = productRepository;
			this._mapper = mapper;
		}

		/// <inheritdoc/>
		public override async Task<IApiResult<SearchProductV2ResponseDto>> Handle(SearchProductV2RequestDto request, CancellationToken cancellationToken)
		{
			var result = new ApiResult<SearchProductV2ResponseDto>();
			var responseDto = new SearchProductV2ResponseDto();

			try
			{
				var products = await _productRepository.GetPagedListAsync(request.PageSize, request.Offset);

				foreach (var product in products)
				{
					responseDto.Products.Add(_mapper.Map<Product, ProductResponseDto>(product));
				}

				result.Data = responseDto;
			}
			catch (Exception ex)
			{
				result.AddError(ex);
				result.ErrorCode = "500";
			}

			return result;
		}
	}
}
