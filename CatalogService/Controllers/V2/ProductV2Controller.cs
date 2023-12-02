using CatalogService.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product;
using System.Net;
using Asp.Versioning;
using Service.Dtos.Product.V2;

namespace CatalogService.Controllers.V2
{
	[ApiVersion("2.0")]
	[ApiExplorerSettings(GroupName = "v2")]
	[Route("api/v{version:apiVersion}/Product")]
	public class ProductV2Controller : BaseController
	{
		public ProductV2Controller(IMediator mediator) : base(mediator)
		{
		}

		[HttpPost]
		[Route("ProductList")]
		[Consumes("application/json")]
		[ProducesResponseType(typeof(SearchProductV2ResponseDto), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetPagedProducts([FromBody] SearchProductV2RequestDto productRequest)
		{
			return ApiResponse(await Mediator.Send(productRequest));
		}
	}
}
