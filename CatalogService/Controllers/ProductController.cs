using CatalogService.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product;
using System.Net;

namespace CatalogService.Controllers
{
	[ApiVersion("1.0")]
	public class ProductController : BaseController
	{
		public ProductController(IMediator mediator) : base(mediator)
		{
		}

		[HttpPost]
		[Route("ProductList")]
		[Consumes("application/json")]
		[ProducesResponseType(typeof(SearchProductsResponseDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetProducts([FromBody] SearchProductsRequestDto productRequest)
		{
			return ApiResponse(await Mediator.Send(productRequest));
		}
	}
}
