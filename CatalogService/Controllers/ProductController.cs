using CatalogService.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product;
using System.Net;
using Asp.Versioning;
using Service.Dtos.Product.Update;

namespace CatalogService.Controllers
{
	/// <summary>
	/// The V1 Product Controller
	/// </summary>
	[ApiVersion("1.0")]
	[ApiExplorerSettings(GroupName = "v1")]
	public class ProductController : BaseController
	{
		/// <summary>
		/// Creates instance of the controller
		/// </summary>
		/// <param name="mediator"></param>
		public ProductController(IMediator mediator) : base(mediator)
		{
		}

		/// <summary>
		/// Gets the products
		/// </summary>
		/// <param name="productRequest"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("ProductList")]
		[Consumes("application/json")]
		[ProducesResponseType(typeof(SearchProductsResponseDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetProducts([FromBody] SearchProductsRequestDto productRequest)
		{
			return ApiResponse(await Mediator.Send(productRequest));
		}

		/// <summary>
		/// Updates the description of the product
		/// </summary>
		/// <param name="updateRequest"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("PartialUpdate")]
		[Consumes("application/json")]
		[ProducesResponseType(typeof(ProductUpdateResponseDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> PartialUpdateProduct([FromBody] ProductUpdateRequestDto updateRequest)
		{
			return ApiResponse(await Mediator.Send(updateRequest));
		}
	}
}
