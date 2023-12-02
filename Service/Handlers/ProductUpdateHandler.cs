using System.ComponentModel;
using AutoMapper;
using Domain;
using Infrastructure.Repositories;
using Service.Dtos.Product.Update;
using Service.Handlers.Base;
using Service.Results;
using System.Reflection;

namespace Service.Handlers
{
	internal class ProductUpdateHandler : BaseHandler<ProductUpdateRequestDto, ProductUpdateResponseDto>
	{
		private readonly IProductRepository productRepository;
		private readonly IMapper mapper;

		public ProductUpdateHandler(IProductRepository productRepository, IMapper mapper)
		{
			this.productRepository = productRepository;
			this.mapper = mapper;
		}

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
