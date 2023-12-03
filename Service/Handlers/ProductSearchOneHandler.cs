using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Service.Dtos.Product;
using Service.Handlers.Base;
using Service.Results;

namespace Service.Handlers
{
	/// <summary>
	/// The ProductSearchOneHandler
	/// </summary>
	public class ProductSearchOneHandler : BaseHandler<ProductRequestDto, ProductResponseDto>
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
		public ProductSearchOneHandler(IProductRepository productRepository, IMapper mapper)
		{
			this._productRepository = productRepository;
			this._mapper = mapper;
		}

		/// <inheritdoc/>
		public override async Task<IApiResult<ProductResponseDto>> Handle(ProductRequestDto request, CancellationToken cancellationToken)
		{
			var result = new ApiResult<ProductResponseDto>();

			try
			{
				var product = await _productRepository.GetAsync(request.ProductId);
				if (product == null)
				{
					result.ErrorCode = "404";
					return result;
				}

				result.Data = _mapper.Map<Product, ProductResponseDto>(product);

				return result;
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
