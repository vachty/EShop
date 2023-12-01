using MediatR;
using Service.Results;

namespace Service.Dtos.Base
{
	public interface IBaseRequestDto<TResponse> : IRequest<IApiResult<TResponse>>
		where TResponse : IBaseResponseDto
	{
	}
}
