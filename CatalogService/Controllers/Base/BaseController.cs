using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Base;
using Service.Results;

namespace CatalogService.Controllers.Base
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/v{api-version:apiVersion}/[controller]")]
	public abstract class BaseController : ControllerBase
	{
		protected BaseController(IMediator mediator)
		{
			Mediator = mediator;
		}

		protected IMediator Mediator { get; }

		protected IActionResult ApiResponse<T>(IApiResult<T> apiDataResult) where T : BaseResponseDto
		{
			if(apiDataResult == null)
				throw  new ArgumentNullException(nameof(apiDataResult));

			if (!apiDataResult.HasErrors)
			{
				return Ok(apiDataResult.Data);
			}

			return Ok(apiDataResult.Data);
		}
	}
}
