using Asp.Versioning;
using CatalogService.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product.V2;
using System.Net;

namespace CatalogService.Controllers.V2
{
	/// <summary>
	/// The V2 ProductController
	/// </summary>
	[ApiVersion("2.0")]
	[ApiExplorerSettings(GroupName = "v2")]
	[Route("api/v{version:apiVersion}/Product")]
	public class ProductV2Controller : BaseController
	{
		/// <summary>
		/// Creates instance of the controller
		/// </summary>
		/// <param name="mediator"></param>
		public ProductV2Controller(IMediator mediator) : base(mediator)
		{
		}

		/// <summary>
		/// Gets the paged collection of products
		/// </summary>
		/// <param name="productRequest"></param>
		/// <returns></returns>
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
