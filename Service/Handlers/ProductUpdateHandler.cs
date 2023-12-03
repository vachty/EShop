using AutoMapper;
using Infrastructure.Repositories;
using Service.Dtos.Product.Update;
using Service.Handlers.Base;
using Service.Results;

namespace Service.Handlers
{
	/// <summary>
	/// The Product Update Handler
	/// </summary>
	public class ProductUpdateHandler : BaseHandler<ProductUpdateRequestDto, ProductUpdateResponseDto>
	{
		/// <summary>
		/// The product repository
		/// </summary>
		private readonly IProductRepository productRepository;

		/// <summary>
		/// The mapper
		/// </summary>
		private readonly IMapper mapper;

		/// <summary>
		/// Create instance of the handler
		/// </summary>
		/// <param name="productRepository"></param>
		/// <param name="mapper"></param>
		public ProductUpdateHandler(IProductRepository productRepository, IMapper mapper)
		{
			this.productRepository = productRepository;
			this.mapper = mapper;
		}

		/// <inheritdoc/>
		public override async Task<IApiResult<ProductUpdateResponseDto>> Handle(ProductUpdateRequestDto request, CancellationToken cancellationToken)
		{
			var result = new ApiResult<ProductUpdateResponseDto>();

			try
			{
				var product = await productRepository.GetAsync(request.ProductId);
				product.Description = request.Description;

				productRepository.Update(product);
				await productRepository.SaveAsync();
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