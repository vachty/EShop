using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Service.Dtos.Product;
using Service.Dtos.Product.V2;
using Service.Handlers.Base;
using Service.Results;

namespace Service.Handlers.V2
{
	public class ProductSearchV2Handler : BaseHandler<SearchProductV2RequestDto, SearchProductV2ResponseDto>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductSearchV2Handler(IProductRepository productRepository, IMapper mapper)
		{
			this._productRepository = productRepository;
			this._mapper = mapper;
		}

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
